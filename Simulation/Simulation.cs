using System;
using laba4oop.Repository;
using laba4oop.Commands;
using laba4oop.Service.Base;
using laba4oop.Service;

namespace laba4oop.Simulation
{
    public abstract class Simulation
    {
        private static DbContext.DbContext dataBase = new DbContext.DbContext();
        private static PlayerRepository _playerRepository = new PlayerRepository(dataBase);
        private static GameRepository _gameRepository = new GameRepository(dataBase);
        private static GameFactory _gameFactory = new GameFactory();
        private static CommandManager _commandManager = new CommandManager();

        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //unicode

            IPlayerService playerService = new PlayerService(_playerRepository);
            IGameService gameService = new GameService(_gameRepository);

            _commandManager.AddCommand(new CreatePlayerCommand(playerService));
            _commandManager.AddCommand(new DisplayPlayersCommand(playerService));
            _commandManager.AddCommand(new DeletePlayerCommand(playerService));
            _commandManager.AddCommand(new EditPlayerCommand(playerService));
            _commandManager.AddCommand(new DisplayPlayerGamesCommand(playerService, gameService));
            _commandManager.AddCommand(new DisplayGamesCommand(gameService));
            _commandManager.AddCommand(new EditGameCommand(gameService));
            _commandManager.AddCommand(new DeleteGameCommand(gameService));
            _commandManager.AddCommand(new StartGameCommand(playerService, gameService, _gameFactory));

            Start();
        }

        private static void Start()
        {
            while (true)
            {
                Console.WriteLine("Start:");
                _commandManager.DisplayCommands();

                var startChoice = GetChoice(1, _commandManager.Commands.Count);
                _commandManager.ExecuteCommand(startChoice - 1);
            }
        }

        private static int GetChoice(int minValue, int maxValue)
        {
            int choice;
            while (true)
            {
                Console.Write($"Enter the number from {minValue} to {maxValue}: ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue)
                {
                    break;
                }

                Console.WriteLine("Wrong input,try again");
            }

            return choice;
        }
    }
}