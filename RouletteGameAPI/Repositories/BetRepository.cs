using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RouletteGameAPI.Models;
using static RouletteGameAPI.Models.BetEnums;

namespace RouletteGameAPI.Repositories
{
    public class BetRepository : IBetRepository
    {
        public async Task<IEnumerable<PlaceBetResponse>> PlaceYourBet(List<PlaceBetRequests> placeBetRequests)
        {
            List<PlaceBetResponse> placebetresponse = new List<PlaceBetResponse>();
            var Winningnumber = SpinTheWheel();
            string WinningColour = FindWinningColour(Winningnumber);
            string WinningOddOrEven = EvenOddNumber(Winningnumber);
            string WinningHighOrLow = HighOrLowNumber(Winningnumber);
          foreach (var placebetRequest in placeBetRequests)
           {
            switch (placebetRequest.BetType)
            {
                case BetType.StraightUp:
                    if (placebetRequest.BettingNumbers == Winningnumber)
                    {
                        placebetresponse.Add(new PlaceBetResponse  
                        {
                            BetType = "StraightUp",
                            Message = "Congratulations, you have won",
                            Win = true,
                            WinningNumber = Winningnumber,
                            PayoutAmount = placebetRequest.BetAmount * 35
                        });
                    }
                    else
                    {
                            placebetresponse.Add(new PlaceBetResponse
                            {
                                BetType = "StraightUp",
                                Message = "Sorry, you lost your bet",
                                Win = false,
                                WinningNumber = Winningnumber,
                                PayoutAmount = 0
                            });
                     }
                    break;
                case BetType.SplitBet:
                    break;
                case BetType.EvenOrOdd:
                    if (placebetRequest.EvenOdd == WinningOddOrEven)
                        {                     
                            placebetresponse.Add(new PlaceBetResponse
                            {
                                BetType = "Even or Odd",
                                Message = "Congratulations, you have won",
                                Win = true,
                                WinningNumber = Winningnumber,
                                PayoutAmount = placebetRequest.BetAmount * 17
                            });

                        }
                        else
                        {
                        placebetresponse.Add(new PlaceBetResponse
                            {
                                BetType = "Even or Odd",
                                Message = "Sorry, you lost your bet",
                                Win = false,
                                WinningNumber = Winningnumber,
                                PayoutAmount = 0
                            });
                        }
                    break;
                case BetType.Colour:
                    if (placebetRequest.BettingColour == WinningColour)
                        {
                        placebetresponse.Add(new PlaceBetResponse
                            {
                                BetType = "Colour",
                                Message = "Congratulations, you have won",
                                Win = true,
                                WinningNumber = Winningnumber,
                                PayoutAmount = placebetRequest.BetAmount * 2
                            });

                        }

                    else
                    {
                            placebetresponse.Add(new PlaceBetResponse
                            {
                                BetType = "Colour",
                                Message = "Sorry, you lost your bet",
                                Win = false,
                                WinningNumber = Winningnumber,
                                PayoutAmount = 0
                            });
                        }
                    break;
                case BetType.HighOrLow:
                    if (placebetRequest.HighLow == WinningHighOrLow)
                    {
                            placebetresponse.Add(new PlaceBetResponse
                            {
                                BetType = "High or Low",
                                Message = "Congratulations, you have won",
                                Win = true,
                                WinningNumber = Winningnumber,
                                PayoutAmount = placebetRequest.BetAmount * 3
                            });
                        }   
                    else
                    {
                            placebetresponse.Add(new PlaceBetResponse
                            {
                                BetType = "Colour",
                                Message = "Sorry, you lost your bet",
                                Win = false,
                                WinningNumber = Winningnumber,
                                PayoutAmount = 0
                            });

                    }
                    break;
                 }              
            }
            //   ("insert into roulettebet (BetType, BettingNumbers, BettingColour, EvenOrOdd, BetAmount, BetPayout,sessionid,playerid)
            //      values (placebetRequest.BetType, placebetRequest.BettingNumbers,placebetRequest.BettingColour,placebetRequest.EvenOrOdd)",placeBetRequests);

            return placebetresponse.ToList();
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

        private string EvenOddNumber(int wnumber)
        {
            int remainder;
            string OddOrEven;
            remainder = wnumber % 2;
            if (remainder == 0)
            {
                OddOrEven = "Even";
            }
            else
            {
                OddOrEven = "Odd";
            }
            return OddOrEven;
        }

        private string HighOrLowNumber(int wnumber)
        {
            string HighorLow;
            if (wnumber > 18)
            {
                HighorLow = "High";
            }
            else
            {
                HighorLow = "Low";
            }
            return HighorLow;
        }



    }
}

