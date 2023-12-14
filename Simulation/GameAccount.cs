using System;
using System.Collections.Generic;

namespace laba4oop.Simulation
{
    public abstract class GameAccount
    {
        private string _userName;
        public int CurrentRating;
        public int GamesCount;
        private List<Result> History { get; set; }

        protected GameAccount(string userName, int initialRating)
        {
            SetUserName(userName);
            if (initialRating < 1)
            {
                throw new ArgumentException("Rating must be > 1");
            }

            CurrentRating = initialRating;
            GamesCount = 0;
            History = new List<Result>();
        }

        protected abstract int CalculateRatingForWin(int gameRating);

        protected abstract int CalculateRatingForLoss(int gameRating);

        public void WinGame(GameAccount opponent, int gameRating)
        {
            int ratingChange = CalculateRatingForWin(gameRating);
            CurrentRating += ratingChange;
            GamesCount++;
            History.Add(new Result(opponent.GetUserName(), true, ratingChange));
        }

        public void LoseGame(GameAccount opponent, int gameRating)
        {
            var ratingChange = CalculateRatingForLoss(gameRating);
            CurrentRating -= ratingChange;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }

            GamesCount++;
            History.Add(new Result(opponent.GetUserName(), false, ratingChange));
        }

        public void GetStats()
        {
            Console.WriteLine($"Stats {_userName} ({GetAccountType()}):");
            for (var i = 0; i < History.Count; i++)
            {
                var result = History[i];
                var output = result.Victory ? "win" : "lose";
                Console.WriteLine(
                    $"Game #{i + 1}: against {result.OpponentName}, Result: {output}, Rating change: {result.RatingChange}");
            }

            Console.WriteLine($"General amount of games: {GamesCount}, Current rating: {CurrentRating}");
        }

        private string GetUserName()
        {
            return _userName;
        }

        public virtual string GetAccountType()
        {
            return "Basic account";
        }

        private void SetUserName(string value)
        {
            _userName = value;
        }
    }
}