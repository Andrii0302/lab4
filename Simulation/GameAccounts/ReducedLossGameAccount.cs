namespace laba4oop.Simulation.GameAccounts
{
    public class ReducedLossGameAccount : GameAccount
    {
        public ReducedLossGameAccount(string userName, int initialRating) : base(userName, initialRating)
        {
        }

        protected override int CalculateRatingForWin(int gameRating)
        {
            return gameRating;
        }

        protected override int CalculateRatingForLoss(int gameRating)
        {
            return gameRating / 2;
        }

        public override string GetAccountType()
        {
            return "Reduced penalty";
        }
    }
}