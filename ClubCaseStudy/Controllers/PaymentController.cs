using AutoMapper;
using ClubCaseStudy.DTOs.Member;
using ClubCaseStudy.DTOs.Payment;
using ClubCaseStudy.Models;
using ClubCaseStudy.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ClubCaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var m = await _unit.payments.GetAll();
            var dto = _mapper.Map<List<GetPaymentDTO>>(m);

            return Ok(dto);

        }

        [HttpPost]
        public IActionResult Add(CreatePaymentDTO dto)
        {

            if (dto == null || !ModelState.IsValid)
                return BadRequest();


            var mem = _mapper.Map<Payment>(dto);
            _unit.payments.Add(mem);
            _unit.Save();
            return Created();

        }

        [HttpGet("Statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var s = await _unit.payments.GetPaymentStatistics();
            return Ok(s);
           
        }
    }
}
