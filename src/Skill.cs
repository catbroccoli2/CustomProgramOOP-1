using System;
using SplashKitSDK;

namespace FirstFantasy
{
    public class Skill
    {
        public string Name {get; protected set;}
        public int MPCost {get; protected set;}
        public int Damage {get; protected set;}

        public Skill(string name, int mpCost, int damage)
        {
            Name = name;
            MPCost = mpCost;
            Damage = damage;
        }

    }
}