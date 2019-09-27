using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_2
{
    abstract class Building
    {
        protected int xPos;
        protected int yPos;
        protected string faction;
        protected string symbol;
        protected int hp;

        public int Hp { get => hp; set => hp = value; }
        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        public string Faction { get => faction; set => faction = value; }
        public string Symbol { get => symbol; set => symbol = value; }

        protected int blueResources;
        protected int redResources;

        public int BlueResources { get => blueResources; set => blueResources = value; }
        public int RedResources { get => redResources; set => redResources = value; }

        public Building(int Xpos, int Ypos, string faction, string symbol)
        {

        }

        public virtual int GenBlueResource()
        {
            return 0;
        }

        public virtual int GenRedResource()
        {
            return 0;
        }

        public string saveString()
        {
            return (XPos + "," + YPos + "," + Hp + "," + Symbol + "," + Faction);
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
