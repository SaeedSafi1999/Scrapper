using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ScrapperAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Scrapper : ControllerBase
    {
        private readonly IDaadScrapper _daadScrapper;
        private readonly IJobBankCanadaCrapper _canadaCrapper;

        public Scrapper(IDaadScrapper daadScrapper, IJobBankCanadaCrapper canadaCrapper)
        {
            _daadScrapper = daadScrapper;
            _canadaCrapper = canadaCrapper;
        }

        [HttpGet("GetData")]
        public async Task<ActionResult<string>> Get()
        {
            try
            {
                var daad = await _daadScrapper.ScrapDaad();
                //var jobbank = await _canadaCrapper.ScrapJobBankSite();
                return Ok($"daad stored with lat lng:{daad}");
            }
            catch (Exception ex)
            {
                return BadRequest($"error:{ex.Message}");
            }
        }
    }
}
