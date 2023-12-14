using System;
using laba4oop.Entities;
using laba4oop.Simulation;
using laba4oop.Simulation.GameType;
using laba4oop.Service.Base;
using laba4oop.Commands.Base;

namespace laba4oop.Commands
{
    public class StartGameCommand : ICommand
    {
        private IPlayerService _playerService;
        private IGameService _gameService;
        private GameFactory _gameFactory;

        public StartGameCommand(IPlayerService playerService, IGameService gameService, GameFactory gameFactory)
        {
            _playerService = playerService;
            _gameService = gameService;
            _gameFactory = gameFactory;
        }

        public void Execute()
        {
            Console.WriteLine("Enter ID of the first player");
            var player1Id = int.Parse(Console.ReadLine() ?? string.Empty);
            var player1 = _playerService.GetPlayerById(player1Id);

            Console.WriteLine("Enter ID of the second player");
            var player2Id = int.Parse(Console.ReadLine() ?? string.Empty);
            var player2 = _playerService.GetPlayerById(player2Id);

            Console.WriteLine("Choose account type:");
            Console.WriteLine("1. Basic");
            Console.WriteLine("2. Reduced penalty account");
            Console.WriteLine("3. Account with win bonuses");
            var accountTypeChoice = GetChoice(1, 3);

            Console.WriteLine("Choose game type:");
            Console.WriteLine("1. Basic game");
            Console.WriteLine("2. Training game");
            Console.WriteLine("3. Solo game");
            var gameTypeChoice = GetChoice(1, 3);

            var player1Account = CreatePlayer(_gameFactory, accountTypeChoice, player1.UserName, player1.CurrentRating);
            var player2Account = CreatePlayer(_gameFactory, accountTypeChoice, player2.UserName, player2.CurrentRating);

            Console.WriteLine("\nGame simulation...");

            for (var i = 0; i < 1; i++)
            {
                var gameRating = new Random().Next(1, 255);
                var game = CreateGame(gameTypeChoice, gameRating);

                player1Account.WinGame(player2Account, game.GetGameRating());
                player2Account.LoseGame(player1Account, game.GetGameRating());

                player1.CurrentRating = player1Account.CurrentRating;
                player1.GamesCount = player1Account.GamesCount;
                _playerService.UpdatePlayer(player1);

                player2.CurrentRating = player2Account.CurrentRating;
                player2.GamesCount = player2Account.GamesCount;
                _playerService.UpdatePlayer(player2);

                var gameEntity = new GameEntity
                {
                    GameRating = gameRating, PlayerId = player1Id, GameType = game.GetGameType(),
                    AccountType = player1Account.GetAccountType()
                };
                _gameService.CreateGame(gameEntity.GameRating);
            }

            Console.WriteLine("\nPlayer stats");
            Console.WriteLine();
            player1Account.GetStats();
            Console.WriteLine();
            player2Account.GetStats();

            Console.WriteLine("Game created");
        }

        private int GetChoice(int minValue, int maxValue)
        {
            int choice;
            while (true)
            {
                Console.Write($"Enter the number from {minValue} to {maxValue}: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue)
                {
                    break;
                }

                Console.WriteLine("Wrong input");
            }

            return choice;
        }

        public GameAccount CreatePlayer(GameFactory factory, int accountTypeChoice, string userName,
            int initialRating)
        {
            switch (accountTypeChoice)
            {
                case 1:
                    return GameFactory.CreateStandardGameAccount(userName, initialRating);
                case 2:
                    return GameFactory.CreateReducedLossGameAccount(userName, initialRating);
                case 3:
                    return GameFactory.CreateWinningStreakGameAccount(userName, initialRating);
                default:
                    throw new ArgumentException("Wrong type of account");
            }
        }

        private Game CreateGame(int gameTypeChoice, int rating)
        {
            switch (gameTypeChoice)
            {
                case 1:
                    return new StandardGame(rating);
                case 2:
                    return new TrainingGame();
                case 3:
                    return new SoloGame(rating);
                default:
                    throw new ArgumentException("Wrong type of game");
            }
        }

        public string GetCommandInfo()
        {
            return "Start the game";
        }
    }
}