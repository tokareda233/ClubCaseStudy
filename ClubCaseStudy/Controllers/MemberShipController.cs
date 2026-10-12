using AutoMapper;
using ClubCaseStudy.DTOs.Member;
using ClubCaseStudy.DTOs.MemberShip;
using ClubCaseStudy.Models;
using ClubCaseStudy.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ClubCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberShipController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public MemberShipController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var m = await _unit.MemberShips.GetAll();
            var dto = _mapper.Map<List<GetMemberShipDTO>>(m);

            return Ok(dto);

        }

        [HttpPost]
        public IActionResult Add(CreateMemberShipDTO dto)
        {

            if (dto == null || !ModelState.IsValid)
                return BadRequest();


            var mem = _mapper.Map<MemberShip>(dto);
            _unit.MemberShips.Add(mem);
            _unit.Save();
            return Created();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        { 
           var mem= await _unit.MemberShips.GetById(id);
            if (mem == null) return NotFound();

            _unit.MemberShips.Delete(mem);
            _unit.Save();
            return NoContent();

        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveMemberships()
        {
            var ac =  await _unit.MemberShips.GetActiveMemberShips();
            var dto = _mapper.Map<List<GetMemberShipDTO>>(ac);
            return Ok(dto);
        }


        [HttpPatch]
        public async Task<IActionResult> PatchByEnddate(int id , DateTime enddate)
        {
            var mem=await _unit.MemberShips.GetById(id);
            if(mem == null) return NotFound();

            var s=await _unit.MemberShips.PatchByEndDate(id, enddate);
            s.EndDate= enddate;
            _unit.MemberShips.Update(s);
            _unit.Save();
            return NoContent();
        }
    }
}
