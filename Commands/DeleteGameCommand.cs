using System;
using laba4oop.Service.Base;
using laba4oop.Commands.Base;

namespace laba4oop.Commands
{
    public class DeleteGameCommand : ICommand
    {
        private IGameService _gameService;

        public DeleteGameCommand(IGameService gameService)
        {
            _gameService = gameService;
        }

        public void Execute()
        {
            Console.WriteLine("Enter game's ID");
            var gameId = int.Parse(Console.ReadLine());
            _gameService.DeleteGame(gameId);
            Console.WriteLine("Game was deleted");
        }

        public string GetCommandInfo()
        {
            return "Delete game";
        }
    }
}