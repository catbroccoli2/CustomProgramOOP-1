using System;


namespace FirstFantasy
{
    public interface ICommand
    {
        void Execute();
        string Describe();
        bool CanExecute();
    }
}