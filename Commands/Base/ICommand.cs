namespace laba4oop.Commands.Base
{
    public interface ICommand
    {
        void Execute();
        string GetCommandInfo();
    }
}