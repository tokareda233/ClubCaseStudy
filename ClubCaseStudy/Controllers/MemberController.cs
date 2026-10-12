using AutoMapper;
using ClubCaseStudy.DTOs.Member;
using ClubCaseStudy.Models;
using ClubCaseStudy.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ClubCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public MemberController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var m = await _unit.Members.GetAll();
            var dto=_mapper.Map<List<GetMemberDTO>>(m);

            return Ok(dto);
        
        }

        [HttpPost]
        public IActionResult Add(CreateMemberDTO dto)
        {
           
            if (dto == null||!ModelState.IsValid)
                return BadRequest();


            var mem=_mapper.Map<Memberr>(dto);
            _unit.Members.Add(mem);
            _unit.Save();
            return Created();
        
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, CreateMemberDTO dto)
        { 
             var mem = await _unit.Members.GetById(id);
            if(mem == null)
            {
               return NotFound();
            }

            _mapper.Map(dto,mem);
            _unit.Members.Update(mem);
            _unit.Save();

            return Ok();
        
        }

        [HttpGet("Pagnation")]
        public async Task<IActionResult> Pagnation(int pagenumber=1,int pagesize = 5)
        {
            var mems=await _unit.Members.Pagnation(pagenumber,pagesize);
            var dto = _mapper.Map<List<GetMemberDTO>>(mems);

            return Ok(dto);
        }

        [HttpGet("Search")]
        public async Task<IActionResult> Search(string Name)
        {
            var mems = await _unit.Members.SearchByName(Name);
            var dto = _mapper.Map<List<GetMemberDTO>>(mems);

            return Ok(dto);
        }


    }
}
