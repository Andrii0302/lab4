using System;
using laba4oop.Entities;
using laba4oop.Service.Base;
using laba4oop.Commands.Base;

namespace laba4oop.Commands
{
    public class CreatePlayerCommand : ICommand
    {
        private IPlayerService _playerService;

        public CreatePlayerCommand(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Execute()
        {
            var newPlayer = new PlayerEntity();
            _playerService.CreatePlayer(newPlayer.UserName, newPlayer.CurrentRating);

            Console.WriteLine($"Player was created");
        }

        public string GetCommandInfo()
        {
            return "Create player";
        }
    }
}