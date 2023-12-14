using System;
using System.Collections.Generic;
using laba4oop.Commands.Base;

namespace laba4oop.Commands
{
    public class CommandManager
    {
        public void AddCommand(ICommand command)
        {
            Commands.Add(command);
        }

        public void DisplayCommands()
        {
            for (var i = 0; i < Commands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Commands[i].GetCommandInfo()}");
            }
        }

        public void ExecuteCommand(int index)
        {
            if (index >= 0 && index < Commands.Count)
            {
                Commands[index].Execute();
            }
            else
            {
                Console.WriteLine("Wrong command");
            }
        }

        public List<ICommand> Commands { get; } = new List<ICommand>();
    }
}