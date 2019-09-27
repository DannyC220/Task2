using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_2
{
    abstract class Unit
    {
        protected int xPosition;
        protected int yPosition;
        protected int hp;
        protected int maxHp; 
        protected int attack;
        protected int speed;
        protected int attackRange;
        protected string faction;
        protected char symbol;
        protected bool isAttacking = false;
        protected bool isDestroyed = false;
        public static Random rand = new Random();

        public Unit(int X, int Y, int Health, int Speed, int Attack, int AttackRange, char Symbol, string Faction)
        {
            this.xPosition = X;
            this.yPosition = Y;
            this.hp = Health;
            maxHp = Health;
            this.speed = Speed;
            this.attack = Attack;
            this.attackRange = AttackRange;
            this.faction = Faction;
            this.symbol = Symbol;
        }

        public abstract int XPosition { get ; set; }
        public abstract int YPosition { get ; set; }
        public abstract int Hp { get ; set; }
        public abstract int MaxHp { get; }
        public abstract string Faction { get; }
        public abstract char Symbol { get; }
        public abstract bool IsDestroyed { get ; }

       

        public abstract Unit GetClosestUnit(Unit[] units);

        public abstract bool InRange(Unit enemy);

        public abstract void Move(Unit closestUnit);

        public abstract void Attack(Unit enemy);

        public abstract void RunAway();

        public abstract void Destroy();

        protected double GetDistance(Unit enemy)
        {
            double distanceX = (enemy.XPosition - XPosition);
            double distanceY = (enemy.YPosition - YPosition);
            return Math.Sqrt(distanceX * distanceX + distanceY * distanceY);
        }

        public override string ToString()
        {
            return "Position" + XPosition + "," + YPosition + "Health" + hp + " / " + maxHp + " Faction " + faction + "Symbol" + symbol;
        }

        public string saveString()
        {
            return (XPosition + "," + YPosition + "," + Hp + "," + Symbol + "," + Faction);
        }

        private void Save()
        {
            FileStream saveUnits = new FileStream("unit.txt", FileMode.Open, FileAccess.Write);
            StreamWriter save = new StreamWriter(saveUnits);
            save.WriteLine(saveString());
            save.Close();
            saveUnits.Close();
        }

       



    }



}
