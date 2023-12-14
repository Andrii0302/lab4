namespace laba4oop.Simulation.GameType
{
    public class StandardGame : Game
    {
        private int _gameRating;

        public StandardGame(int rating)
        {
            _gameRating = rating;
        }

        public override int GetGameRating()
        {
            return _gameRating;
        }

        public override string GetGameType()
        {
            return "Basic game";
        }
    }
}