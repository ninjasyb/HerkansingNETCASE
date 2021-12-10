using CursusInzicht.API.Services.Interfaces;
using CursusInzicht.Domain.Interfaces;
using CursusInzicht.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CursusInzicht.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursusInstantieController : ControllerBase
    {
        private readonly ICursusInstantieRepository _cursusInstantieRepository;
        private readonly IWeekNumberService _weekNumberService;

        public CursusInstantieController(   ICursusInstantieRepository cursusInstantieRepository,
                                            IWeekNumberService weekNumberService) {
            _cursusInstantieRepository = cursusInstantieRepository;
            _weekNumberService = weekNumberService;
        }

        // GET: api/cursusinstantie
        [HttpGet]
        public async Task <IEnumerable<CursusInstantie>> Get(int jaar = 0, int weekNr = 0) {
            
            if(jaar == 0 && weekNr == 0) {
                DateTime eersteWeekDag = _weekNumberService.FirstDateOfWeekISO8601(
                                                                                    DateTime.Now.Year,
                                                                                    _weekNumberService.GetIso8601WeekOfYear(DateTime.Now));
                return await _cursusInstantieRepository.GetInstancesFromWeek(eersteWeekDag);
            } else {
                DateTime eersteWeekDag = _weekNumberService.FirstDateOfWeekISO8601(jaar, weekNr);
                return await _cursusInstantieRepository.GetInstancesFromWeek(eersteWeekDag);
            }
        }
    }
}
