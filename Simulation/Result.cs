namespace laba4oop.Simulation
{
    public class Result
    {
        public string OpponentName { get; set; }
        public bool Victory { get; set; }
        public int RatingChange { get; set; }

        public Result(string opponentName, bool victory, int ratingChange)
        {
            OpponentName = opponentName;
            Victory = victory;
            RatingChange = ratingChange;
        }
    }
}