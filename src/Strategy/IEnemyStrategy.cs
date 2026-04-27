using System;
using SplashKitSDK;

namespace FirstFantasy
{
    public interface IEnemyStrategy
    {
        ICommand ChooseAction(Enemy self, Player target);
    }
}  