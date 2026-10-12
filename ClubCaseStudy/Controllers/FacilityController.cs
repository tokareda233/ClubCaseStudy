using AutoMapper;
using ClubCaseStudy.DTOs.Facility;
using ClubCaseStudy.DTOs.MemberShip;
using ClubCaseStudy.Models;
using ClubCaseStudy.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public FacilityController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var m = await _unit.Facilities.GetAll();
            var dto = _mapper.Map<List<GetFacilityDTO>>(m);

            return Ok(dto);

        }

        [HttpPost]
        public IActionResult Add(CreateFacilityDTO dto)
        {

            if (dto == null || !ModelState.IsValid)
                return BadRequest();


            var mem = _mapper.Map<Facility>(dto);
            _unit.Facilities.Add(mem);
            _unit.Save();
            return Created();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var mem = await _unit.Facilities.GetById(id);
            if (mem == null) return NotFound();


            _unit.Facilities.Delete(mem);
            _unit.Save();
            return NoContent();

        }

    }
}
