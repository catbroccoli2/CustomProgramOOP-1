using System;
using SplashKitSDK;

namespace FirstFantasy
{
    public class AggressiveStrategy : IEnemyStrategy
    {
        
        public ICommand ChooseAction(Enemy self, Player target)
        {
            return new AttackCommand(self, target);
        }
    }
}