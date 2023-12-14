using System;
using System.Linq;
using laba4oop.Service.Base;
using laba4oop.Commands.Base;

namespace laba4oop.Commands
{
    public class DisplayPlayerGamesCommand : ICommand
    {
        private IPlayerService _playerService;
        private IGameService _gameService;

        public DisplayPlayerGamesCommand(IPlayerService playerService, IGameService gameService)
        {
            _playerService = playerService;
            _gameService = gameService;
        }

        public void Execute()
        {
            Console.WriteLine("Enter player's ID");
            var playerId = int.Parse(Console.ReadLine() ?? string.Empty);
            var selectedPlayer = _playerService.GetPlayerById(playerId);

            if (selectedPlayer == null)
            {
                Console.WriteLine("Player does not exist");
                return;
            }

            Console.WriteLine($"List of player's games {selectedPlayer.UserName}:");

            var games = _gameService.GetAllGames().Where(game => game.PlayerId == playerId);
            foreach (var game in games)
            {
                Console.WriteLine(
                    $"Game's ID {game.Id}, game rating {game.GameRating}, game type {game.GameType}, account type {game.AccountType}, Win: {game.IsWin}");
            }
        }

        public string GetCommandInfo()
        {
            return "List of player's played games";
        }
    }
}