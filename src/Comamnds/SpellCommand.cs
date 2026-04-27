using System;
using SplashKitSDK;

namespace FirstFantasy
{
    public class SpellCommand : ICommand
    {
        private Character _caster;
        private Character _target;
        private Skill _skill;
        private int _damageDealt;

        public SpellCommand(Character caster, Character target, Skill skill)
        {
            _caster = caster;
            _target = target;
            _skill = skill;
        }




        public bool CanExecute()
        {
            return _caster.MP >= _skill.MPCost && _caster.IsAlive && _target.IsAlive;
        }

        public void Execute()
        {
            _caster.SpendMP(_skill.MPCost);
            _damageDealt = _target.TakeDamage(_skill.Damage);
        }

        public string Describe()
        {
            return $"{_caster.Name} casts the spell {_skill.Name} dealing {_damageDealt} damage!";
        }

        
    }
}