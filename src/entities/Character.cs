using System;
using System.Diagnostics;
using SplashKitSDK;

namespace FirstFantasy
{
    public abstract class Character : Entity
    {
        public string Name { get; protected set; }
        public int HP { get; protected set; }
        public int MaxHP { get; protected set; }
        public int Attack {get; protected set; }
        public int MP {get; protected set;}
        public int MaxMP {get; protected set;}
        public bool IsDefending {get; protected set;}


        public Character(string name, int MaxHp, int attack, double StartX, double StartY, int maxMp) : base(StartX, StartY, 50, 50)
        {
            Name = name;
            HP = MaxHp;
            MaxHP = MaxHp;
            Attack = attack;
            MP = maxMp;
            MaxMP = maxMp;

        }

        public bool IsAlive => HP > 0;

        public bool Defend()
        {   
            return IsDefending = true;
        }
        public virtual int TakeDamage(int Amount)
        {
            int actualDamage;
            if (IsDefending) 
            {
                actualDamage = Amount /2;
                IsDefending = false;
                
            }
            else
            {
                actualDamage = Amount;
            }
            
            HP = System.Math.Max(0, HP - actualDamage);
            if (HP == 0) {IsActive = false;}

            return actualDamage;
        }

        public void SpendMP(int amount)
        {
            MP = System.Math.Max(0, MP - amount);
        }

        
        public void Reset()
        {
            HP = MaxHP;
            MP = MaxMP;
            IsDefending = false;
            IsActive = true;
        }
    }
}