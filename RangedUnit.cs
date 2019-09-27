using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_2
{
    class RangedUnit : Unit
    {
        

        public RangedUnit(int Xposition, int Yposition, string Faction) : base(Xposition, Yposition, 100, 1, 10, 3, 'R', Faction)
        {

        }

        public override string ToString()
        {
            string[] unitType = GetType().ToString().Split('.');
            string typeOne = unitType[unitType.Length - 1];

            return faction + "," + typeOne + "," + (XPosition + 1) + "," + (YPosition + 1) + "," + Hp;
        }

        public override int XPosition
        {
            get { return xPosition; }
            set { xPosition = value; }
        }

        public override int YPosition
        {
            get { return yPosition; }
            set { yPosition = value; }
        }

        public override int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public override int MaxHp
        {
            get { return hp; }
        }

        public override string Faction
        {
            get { return faction; }
        }

        public override char Symbol
        {
            get { return symbol; }
        }

        public override bool IsDestroyed
        {
            get { return isDestroyed; }
        }

       

        public override bool InRange(Unit enemy)
        {
            return GetDistance(enemy) <= attackRange;
        }

        public override void Destroy()
        {
            isDestroyed = true;
            isAttacking = false;
            symbol = 'X';
        }

        public override Unit GetClosestUnit(Unit[] units)
        {
            int tempDistance = 200;
            int Distance = tempDistance;
            Unit returnedUnit = null;

            for (int k = 0; k < units.Length; k++)
            {
                if (Distance < 0)
                {
                    Distance = Math.Abs(Distance);
                }
                // will attack if a units hp is higher than 0, and if it is not in the same faction as the unit.
                if (units[k] != null && units[k].Hp > 0 && units[k].Faction != this.Faction)
                {
                    Distance = ((this.XPosition - units[k].XPosition) ^ 2 + (this.YPosition - units[k].YPosition) ^ 2) ^ 1 / 2;
                }

                if (Distance < tempDistance)
                {
                    tempDistance = Distance;
                    returnedUnit = units[k];
                }
            }
            return returnedUnit;
        }

        public override void Move(Unit enemy)
        {
            if (enemy != null)
            {
                int distanceX = (enemy.XPosition - XPosition);
                int distanceY = (enemy.YPosition - YPosition);

                if (Math.Abs(distanceX) < Math.Abs(distanceY))
                {
                    if (distanceX < 0)
                        XPosition--;
                    else if (distanceX > 0)
                        XPosition++;
                }
                else if (Math.Abs(distanceY) < Math.Abs(distanceX))
                {
                    if (distanceY < 0)
                        YPosition--;
                    else if (distanceX > 0)
                        YPosition++;
                }
            }
        }

        //public override bool InRange(Unit enemy)
        //{
        //    int distance = 300;

        //    if (enemy != null)
        //    {
        //        distance = ((XPosition - enemy.XPosition) ^ 2 + (YPosition - enemy.YPosition) ^ 2) ^ 1 / 2;  // Range calculations
        //    }
        //    if (distance <= this.attackRange)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public override void Destroy()
        //{
        //    isDestroyed = true;
        //    isAttacking = false;
        //    symbol = 'X';
        //}

        public override void Attack(Unit enemy)
        {
            isAttacking = false;
            enemy.Hp -= attack;

            if (enemy.Hp <= 0)
            {
                enemy.Destroy();
            }
        }

        public override void RunAway() // if 1 is selected move up, if 2 is selected move right, if 3 is selected move left and if 4 is selected move down
        {
            bool valid = false;
            int move = 0;

            while (valid == false)
            {
                move = rand.Next(1, 5);
                if (YPosition == 0 && move == 1)
                    valid = false;
                else if (XPosition == 19 && move == 2)
                    valid = false;
                else if (YPosition == 19 && move == 3)
                    valid = false;
                else if (XPosition == 0 && move == 4)
                    valid = false;
                else
                    valid = true;

            }

            switch (move)
            {
                case 1:
                    YPosition--;
                    break;
                case 2:
                    XPosition++;
                    break;
                case 3:
                    YPosition++;
                    break;
                case 4:
                    XPosition--;
                    break;
            }
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
