using System;
using laba4oop.Commands.Base;
using laba4oop.Service.Base;

namespace laba4oop.Commands
{
    public class DeletePlayerCommand : ICommand
    {
        private IPlayerService _playerService;

        public DeletePlayerCommand(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Execute()
        {
            Console.WriteLine("Enter player's ID");
            var answer = Console.ReadLine();

            if (!int.TryParse(answer, out var id))
            {
                Console.WriteLine("Player does not exist");
            }

            var getPlayer = _playerService.GetPlayerById(id);

            if (getPlayer == default)
            {
                Console.WriteLine("Player does not exist");
            }

            _playerService.DeletePlayer(id);
            Console.WriteLine("Player deleted");
        }

        public string GetCommandInfo()
        {
            return "Delete player";
        }
    }
}