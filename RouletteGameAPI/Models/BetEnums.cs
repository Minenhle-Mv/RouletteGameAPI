using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace RouletteGameAPI.Models
{
    public class BetEnums
    {

        public enum BetType
        {
            StraightUp = 1,
            SplitBet = 2,
            EvenOrOdd = 3,
            Colour = 4,
            HighOrLow = 5
        }


    }
}
