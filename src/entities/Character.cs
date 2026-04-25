using System;
using SplashKitSDK;

namespace FirstFantasy
{
    public abstract class Character : Entity
    {
        public string Name { get; protected set; }
        public int HP { get; protected set; }
        public int MaxHP { get; protected set; }
        public int Attack {get; protected set; }


        public Character(string name, int MaxHp, int Hp, int attack, double StartX, double StartY) : base(StartX, StartY, 50, 50)
        {
            Name = name;
            HP = MaxHp;
            MaxHP = MaxHp;
            Attack = attack;

        }

        public bool IsAlive => HP > 0;
        public virtual void TakeDamage(int Amount)
        {
            HP = System.Math.Max(0, HP - Amount);
            if (HP == 0) {IsActive = false;}

        }

        

        
    }
}