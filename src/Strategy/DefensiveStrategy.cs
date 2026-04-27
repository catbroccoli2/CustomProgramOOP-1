using System;


namespace FirstFantasy
{
    public class DefensiveStrategy : IEnemyStrategy
    {
        
        public ICommand ChooseAction(Enemy self, Player target)
        {
            double lowHP = 0.33 * self.MaxHP;
            if (self.HP <= lowHP)
            {
                return new DefendCommand(self);
            }
            else
            {
                return new AttackCommand(self, target);
            }
        }
    }
}