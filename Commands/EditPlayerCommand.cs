using System;
using laba4oop.Service.Base;
using laba4oop.Commands.Base;

namespace laba4oop.Commands
{
    public class EditPlayerCommand : ICommand
    {
        private IPlayerService _playerService;

        public EditPlayerCommand(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public void Execute()
        {
            Console.WriteLine("Enter player's ID");
            var playerId = int.Parse(Console.ReadLine() ?? string.Empty);
            var player = _playerService.GetPlayerById(playerId);

            if (player == null)
            {
                Console.WriteLine("Player does not exist");
                return;
            }

            Console.WriteLine("Choose what you want to change:");
            Console.WriteLine("1. Player's name");
            Console.WriteLine("2. Current rating");
            Console.WriteLine("3. Amount of played games");
            var editChoice = GetChoice(1, 3);

            switch (editChoice)
            {
                case 1:
                    Console.WriteLine("Enter the new username");
                    var newName = Console.ReadLine();
                    player.UserName = newName;
                    break;
                case 2:
                    Console.WriteLine("Enter the new rating");
                    var newRating = int.Parse(Console.ReadLine() ?? string.Empty);
                    player.CurrentRating = newRating;
                    break;
                case 3:
                    Console.WriteLine("Enter the new amount of played games");
                    var newGamesCount = int.Parse(Console.ReadLine() ?? string.Empty);
                    player.GamesCount = newGamesCount;
                    break;
            }

            _playerService.UpdatePlayer(player);
            Console.WriteLine("Player was updated");
        }

        public string GetCommandInfo()
        {
            return "Edit the player";
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

                Console.WriteLine("Wrong input.");
            }

            return choice;
        }
    }
}