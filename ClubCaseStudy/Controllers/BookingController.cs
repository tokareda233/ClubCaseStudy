using AutoMapper;
using ClubCaseStudy.DTOs.Booking;
using ClubCaseStudy.DTOs.Member;
using ClubCaseStudy.Models;
using ClubCaseStudy.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public BookingController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var m = await _unit.Bookings.GetAll();
            var dto = _mapper.Map<List<GetBookingDTO>>(m);

            return Ok(dto);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var m = await _unit.Bookings.GetById(id);
            var dto = _mapper.Map<GetBookingDTO>(m);

            return Ok(dto);

        }
        [HttpPost]
        public IActionResult Add(CreateBookingDTO dto)
        {

            if (dto == null || !ModelState.IsValid)
                return BadRequest();


            var mem = _mapper.Map<Booking>(dto);
            _unit.Bookings.Add(mem);
            _unit.Save();
            return Created();

        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, CreateBookingDTO dto)
        {
            var mem = await _unit.Bookings.GetById(id);
            if (mem == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, mem);
            _unit.Bookings.Update(mem);
            _unit.Save();

            return Ok();

        }

        [HttpGet("Pagnation")]
        public async Task<IActionResult> Pagnation(string?Status,int ?FacilityId,int pagenumber=1,int pagesize=5)
        {
            var mems=await _unit.Bookings.Pagnation(Status,FacilityId, pagenumber,pagesize);
            var dto = _mapper.Map<List<GetBookingDTO>>(mems);
            return Ok(dto);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var mem = await _unit.Bookings.GetById(id);
            if (mem == null) return NotFound();

            _unit.Bookings.Delete(mem);
            _unit.Save();
            return NoContent();

        }


        [HttpGet("Reports")]
        public async Task<IActionResult> GetReports(){
            var mems = await _unit.Bookings.BookingReport();
            var s = mems.Select(x=> new
            {
                 Id = x.Id,
                 BookingDate =x.BookingDate,
                 StartDate=x.StartDate,
                 EndDate=x.EndDate,
                 GroupSize =x.GroupSize,
                 Status =x.Status,
                 MemberId =x.MemberId,
                 MemberName=x.Member.FullName,
                 FacilityId =x.FacilityId,
                 FacilityName=x.Facility.Name

             }).ToList();

            return Ok(s);

        }

        [HttpPatch("Cancel")]
        public async Task<IActionResult> CancelBooking(int id) 
        {
            var b =await _unit.Bookings.GetById(id);
            if (b == null) return NotFound();

           var book= await _unit.Bookings.Patch(id);
            book.Status = "Cancel";

            _unit.Bookings.Update(book);
            _unit.Save();
            return NoContent();
        
        }
        

    }
}
