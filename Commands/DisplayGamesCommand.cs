using System;
using laba4oop.Commands.Base;
using laba4oop.Service.Base;

namespace laba4oop.Commands
{
    public class DisplayGamesCommand : ICommand
    {
        private IGameService _gameService;

        public DisplayGamesCommand(IGameService gameService)
        {
            _gameService = gameService;
        }

        public void Execute()
        {
            Console.WriteLine("List of all played games:");

            foreach (var gameEntity in _gameService.GetAllGames())
            {
                Console.WriteLine(
                    $"Game's ID {gameEntity.Id}, game rating {gameEntity.GameRating}, game type {gameEntity.GameType}, account type {gameEntity.AccountType}, Win: {gameEntity.IsWin}");
            }
        }

        public string GetCommandInfo()
        {
            return "List of games";
        }
    }
}