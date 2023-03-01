using static RouletteGameAPI.Models.BetEnums;

namespace RouletteGameAPI.Models
{
    public class PlaceBetResponse
    {
        public string BetType { get; set; }
        public bool Win { get; set; }
        public string Message { get; set; }
        public int WinningNumber { get; set; }
        public double PayoutAmount { get; set; }


    }
}
