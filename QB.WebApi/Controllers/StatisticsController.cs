using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QB.Services.Interfaces;
using QB.Services.Models;
using QB.WebApi.Mapping;

namespace QB.WebApi.Controllers
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsController : ControllerBase
    {
        private readonly ILogger<StatisticsController> logger;
        private readonly IStatServiceFacade statService;

        public StatisticsController(ILogger<StatisticsController> logger, IStatServiceFacade statService)
        {
            this.logger = logger;
            this.statService = statService;
        }

        [HttpGet("population")]
        public async Task<IActionResult> GetPopulationStats()
        {
            try
            {
                IEnumerable<CountryPopulation> data = await statService.GetCountryPopulationAsync();
                
                var result = data.Select(MappingHelper.ToViewModel).OrderBy(e => e.CountryName);
                return Ok(result);
            }
            catch(Exception e)
            {
                const string msg = "An error occured while processing country population data";
                
                logger.LogError(e, msg);
                return Problem(msg);
            }
        }
    }
}
