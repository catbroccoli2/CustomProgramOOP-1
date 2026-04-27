using System;

namespace FirstFantasy
{
    public class EnragedStrategy : IEnemyStrategy
{
    public ICommand ChooseAction(Enemy self, Player target)
    {
        // Enraged enemies always attack, never defend, even if low HP
        return new AttackCommand(self, target);
    }
}
}