namespace RouletteGameAPI.Services
{
    public class SpinRoulette
    {

        public static int SpinTheWheel()
        {
            Random rnd = new Random();
            int spinum = rnd.Next(0, 37);

            return spinum;
        }

    }

    //public void GenerateSpin()
    //{
    //    Random rdm = new Random();
    //    WinningNumber = rdm.Next(0, 37);
    //    //return WinningNumber;
    //}

    ////in the image illustrated black numbers are odd
    ////and even numbers are red
    //public void FindWinningColour(int WinningNumber)
    //{
    //    int remainder;
    //    remainder = WinningNumber % 2;
    //    if (remainder == 0)
    //        WinningColor = "Red";
    //    else
    //        WinningColor = "Black";
    //}

}
