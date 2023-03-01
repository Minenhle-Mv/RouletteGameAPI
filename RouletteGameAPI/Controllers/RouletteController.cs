using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using RouletteGameAPI.Models;
using RouletteGameAPI.Repositories;
using static RouletteGameAPI.Models.BetEnums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RouletteGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {

        private readonly IBetRepository _betrepository;
        private readonly IPreviousSpinRepository _previouspinrepository;


        public RouletteController(IBetRepository betrepository, IPreviousSpinRepository previouspinrepository)
        {
            _betrepository = betrepository;
            _previouspinrepository = previouspinrepository;
        }

        //public RouletteController (IPreviousSpinRepository previouspinrepository, IBetRepository betrepository)
        //{
        //    _previouspinrepository = previouspinrepository;
        //    _betrepository = betrepository;
        //}


        [HttpGet]
        [Route("Show Previous Spins")]
        public async Task<ActionResult<IEnumerable<PreviousSpinResponse>>> ShowPreviousSpins()
        {
            try
            { 
                var previousSpins = await _previouspinrepository.ShowPreviousSpins();
                return Ok(previousSpins);
            }

            catch (Exception ex)
            {
                return BadRequest("Bad Request");
            }
        }

        [HttpPost]
        [Route("PlaceBetAndSpin")]
        //public async Task<ActionResult<PlaceBetResponse>> PlaceYourBet(List<PlaceBetRequests> placeBetRequests)
        public ActionResult PlaceYourBet(PlaceBetRequests placeBetRequests)
        {

            var placebetresponse =  _betrepository.PlaceYourBet(placeBetRequests);
            return Ok(placebetresponse);
        }


    }
}
