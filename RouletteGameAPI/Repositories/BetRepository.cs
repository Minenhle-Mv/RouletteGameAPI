using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouletteGameAPI.Models;
using static RouletteGameAPI.Models.BetEnums;

namespace RouletteGameAPI.Repositories
{    
    public class BetRepository : IBetRepository
    {
       //Task<PlaceBetResponse> PlaceYourBet(List<PlaceBetRequests> placeBetRequests)
       // public PlaceBetResponse PlaceYourBet(List<PlaceBetRequests> placeBetRequests)
        public PlaceBetResponse PlaceYourBet(PlaceBetRequests placeBetRequests)

        {
            var placebetresponse = new PlaceBetResponse();
            var Winningnumber = SpinTheWheel();
            string WinningColour = FindWinningColour(Winningnumber);          
            // foreach (var placebetRequest in placeBetRequests)
            // {
            //switch (placebetRequest.BetType)
            switch (placeBetRequests.BetType)
            {
                    case BetType.StraightUp:
                        if  (placeBetRequests.BettingNumbers == Winningnumber)
                            {
                               placebetresponse.BetType = "StraightUp";
                               placebetresponse.Message = "Congratulations, you have won";
                               placebetresponse.Win = true;
                               placebetresponse.WinningNumber = Winningnumber;
                               placebetresponse.PayoutAmount = placeBetRequests.BetAmount * 0.17;

                            }
                            else
                            {
                                placebetresponse.BetType = "StraightUp";
                                placebetresponse.Message = "Sorry, you lost your bet";
                                placebetresponse.Win = false;
                                placebetresponse.WinningNumber = Winningnumber;
                                placebetresponse.PayoutAmount = 0;
                            }
                        break;
                    case BetType.SplitBet:
                        break;
                    case BetType.EvenOrOdd:
                        break;
                    case BetType.Colour:
                        if (placeBetRequests.BettingColour == WinningColour)
                        {
                        placebetresponse.BetType = "Colour";
                        placebetresponse.Message = "Congratulations, you have won";
                        placebetresponse.Win = true;
                        placebetresponse.WinningNumber = Winningnumber;
                        placebetresponse.PayoutAmount = placeBetRequests.BetAmount * 0.17;
                    }
                        else
                        {
                        placebetresponse.BetType = "Colour";
                        placebetresponse.Message = "Sorry, you lost your bet";
                        placebetresponse.Win = false;
                        placebetresponse.WinningNumber = Winningnumber;
                        placebetresponse.PayoutAmount = 0;
                    }
                        break;
                    case BetType.HighOrLow:
                        break;
                    //  }              
            }
         //   ("insert into roulettebet (BetType, BettingNumbers, BettingColour, EvenOrOdd, BetAmount, BetPayout) values 

            return placebetresponse;
        }

        public static int SpinTheWheel()
        {
            Random rnd = new Random();
            int spinum = rnd.Next(0, 37);

            return spinum;
        }


        private string FindWinningColour(int wnumber)
        {
            //picture illustrated odd numbers in black and even numbers in red
            int remainder;
            string WinningColor;
            remainder = wnumber % 2;
            if (remainder == 0)
            {
                WinningColor = "Red";
            }
            else
            {
                WinningColor = "Black";
            }

            return WinningColor;
        }

    }
}
