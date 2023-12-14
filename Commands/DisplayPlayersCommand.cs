using System;
using laba4oop.Service.Base;
using laba4oop.Commands.Base;

namespace laba4oop.Commands
{
    public class DisplayPlayersCommand : ICommand
    {
        private IPlayerService _playerService;

        public DisplayPlayersCommand(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Execute()
        {
            foreach (var player in _playerService.GetAllPlayers())
            {
                Console.WriteLine($"Player's ID {player.Id}, name {player.UserName}, current rating {player.CurrentRating}, amount of player's games {player.GamesCount}");
            }
        }

        public string GetCommandInfo()
        {
            return "List of players";
        }
    }
}