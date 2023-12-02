using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ScrapperAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IJobAndEjucationServices _services;

        public DataController(IJobAndEjucationServices services)
        {
            _services = services;
        }

        [HttpGet("GetData")]
        public async Task<ActionResult<JobsAndEgucationsDTO>> GetData(float lat1, float lat2, float lon1, float lon2)
        {
            return Ok(await _services.GetData(lat1, lon1, lat2, lon2));
        }
    }
}
