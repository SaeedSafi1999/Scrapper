using Core.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ScrapperAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Scrapper : ControllerBase
    {
        private readonly IDaadScrapper _daadScrapper;
        private readonly ILinkedInScrapper _linkedInScrapper;
        private readonly IJobBankCanadaCrapper _canadaCrapper;

        public Scrapper(IDaadScrapper daadScrapper, IJobBankCanadaCrapper canadaCrapper, ILinkedInScrapper linkedInScrapper)
        {
            _daadScrapper = daadScrapper;
            _canadaCrapper = canadaCrapper;
            _linkedInScrapper = linkedInScrapper;
        }

        [HttpPost("GetDataFromLinkedIn")]
        public async Task<ActionResult<string>> Get(LinkedInScrapperDTO Request)
        {
            try
            {
                var linkedin = await _linkedInScrapper.Scrap(Request);
                return Ok($"daad stored with lat lng:{linkedin}");
            }
            catch (Exception ex)
            {
                return BadRequest($"error:{ex.Message}");
            }
        }
    }
}
