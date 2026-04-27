using System;
using SplashKitSDK;

namespace FirstFantasy
{
    public class DefendCommand : ICommand
    {

        private Character _character;

        public DefendCommand(Character character)
        {
            _character = character;
        }

        public bool CanExecute()
        {
            return _character.IsAlive;
        }

        public string Describe()
        {
            return $"{_character.Name} braces for an attack";
        }

        public void Execute()
        {
           _character.Defend();
        }
    }
}