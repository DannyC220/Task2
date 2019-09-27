using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_2
{
    class ResourceBuilding : Building
    {
        
        public ResourceBuilding(int Xpos, int Ypos, string faction, string symbol) : base(Xpos, Ypos, faction, " ")
        {
            this.hp = 50;
            this.XPos = Xpos;
            this.YPos = Ypos;
            this.faction = faction;
            this.symbol = symbol;

            this.blueResources = BlueResources;
            this.redResources = RedResources;
        }

       

        public override int GenBlueResource()
        {
            return BlueResources++;
        }

        public override int GenRedResource()
        {
            return redResources++;
        }

        public override string ToString()
        {
            string[] unitType = GetType().ToString().Split('.');
            string myType = unitType[unitType.Length - 1];

            return Faction + "," + myType + "," + (XPos + 1) + "," + (YPos + 1) + "," + Hp;
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
