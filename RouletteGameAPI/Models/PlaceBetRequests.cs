using Microsoft.AspNetCore.Mvc.Rendering;
using static RouletteGameAPI.Models.BetEnums;

namespace RouletteGameAPI.Models
{
    public class PlaceBetRequests
    {

        public BetType BetType { get; set; }
        public double BetAmount { get; set; }
        public int BettingNumbers { get; set; }
        public string BettingColour { get; set; }
        public string EvenOdd { get; set; }
        public string HighLow { get; set; }
        //public string playerID { get; set; }

    }

}
