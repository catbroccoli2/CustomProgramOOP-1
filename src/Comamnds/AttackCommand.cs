using System;


namespace FirstFantasy
{
    public class AttackCommand : ICommand
    {
        private Character _attacker;
        private Character _target;
        private int _damageDealt;

        public AttackCommand(Character attacker, Character target){
            _attacker = attacker;
            _target = target;
        }
        
        public bool CanExecute()
        {
            return _attacker.IsAlive && _target.IsAlive;
        }

        public string Describe()
        {
            return $"{_attacker.Name} attacked {_target.Name} and Dealt: {_damageDealt} Damage!";
        }

        public void Execute()
        {
            if (!CanExecute()) return;
            _damageDealt = Math.Max(1, _attacker.Attack);
            _target.TakeDamage(_damageDealt);
        }
    }
}