using Microsoft.AspNetCore.Mvc;
using RouletteGameAPI.Models;
using RouletteGameAPI.Repositories;
using System.Collections.Generic;
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

        [HttpGet]
        [Route("ShowPreviousSpins")]
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
         public async Task<ActionResult<IEnumerable<PlaceBetResponse>>> PlaceYourBet(List<PlaceBetRequests> placeBetRequests)
        {
            try
            {
                var placebetresponse = await _betrepository.PlaceYourBet(placeBetRequests);
                return placebetresponse.ToList();
            }

            catch (Exception ex)
            {
                return BadRequest("Bad Request");
            }
        }


    }
}
