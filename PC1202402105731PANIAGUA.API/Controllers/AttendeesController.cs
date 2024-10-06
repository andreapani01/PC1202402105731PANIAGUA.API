using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PC1202402105731PANIAGUA.DOMAIN.Core.Entities;
using PC1202402105731PANIAGUA.DOMAIN.Core.Interfaces;


namespace PC1202402105731PANIAGUA.API.Controllers
{
    public class AttendeesController : ControllerBase
    {

        private readonly IAttendeesRepository _attendeesRepository;
        public AttendeesController(IAttendeesRepository attendeesRepository)
        {
            _attendeesRepository = attendeesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendes()
        {
            var attendees = await _attendeesRepository.GetAttendes();
            return Ok(attendees);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Attendees attendees)
        {
            int id = await _attendeesRepository.Insert(attendees);
            return Ok(id);
        }
    }
