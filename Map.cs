using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_2
{
    class Map
    {
        int mapSize = 20;
        Random rand = new Random();
        int numUnits;
        int numBuild;
        Unit[] units;
        Building[] building;

        string[,] map;
        string[] factions = { "A-team", "B-team" };
        
        //public Unit[] units = new Unit[10];
        //string[] Names = new string[] { "Tashina", "Keren", "Elane", "Sharonda", "Darrick", "Myrtice", "Tawana", "Irvin", "Nadene", "Phoebe", "Hilaria", "Shera", "Monty", "Jolyn", "Minh", "Solomon", "Jami", "Shalanda", "Kristina", "Su " };

        //Random rnd = new Random();

        public Map(int numUnits, int numBuilding)
        {
            this.numUnits = numUnits;
            this.numBuild = numBuilding;
            Reset();
        }

        public Unit[] Units
        {
            get { return units; }
        }

        public Building[] build
        {
            get { return building; }
        }
        public int Size
        {
            get { return mapSize; }
        }

        public string GetMapDisplay()
        {
            string mapString = "";
            for(int y =0; y < mapSize; y++)
            {
                for(int x =0; x < mapSize; x++)
                {
                    mapString += map[x, y];
                }
                mapString += "\n";
            }
            return mapString;
        }

        public void Reset()
        {
            map = new string[mapSize, mapSize];
            units = new Unit[numUnits];
            building = new Building[numBuild];
            InitializeUnits();
            initializeBuildings();
            updateMap();
           
        }

        public void updateMap()
        {
            for(int y=0; y < mapSize; y++)
            {
                for(int x =0; x < mapSize; x++)
                {
                    map[x, y] = " . ";
                }
            }

            foreach(Unit unit in Units)
            {
                map[unit.XPosition, unit.YPosition] = unit.Faction[0] + "/" + unit.Symbol;
            }

            foreach(Building build in build)
            {
                map[build.XPos, build.YPos] = build.Faction[1] + " " + build.Symbol;
            }
            
            

           
            
        }



       

        private void InitializeUnits()
        {
            for (int i = 0; i < units.Length; i++)
            {
                int x = rand.Next(0, mapSize);
                int y = rand.Next(0, mapSize);
                int factionIndex = rand.Next(0, 2);
                int unitType = rand.Next(0, 2);

                while (map[x, y] != null)
                {
                    x = rand.Next(0, mapSize);
                    y = rand.Next(0, mapSize);
                }

                if (unitType == 0)
                {
                    units[i] = new MeleeUnit(x, y, factions[factionIndex]);
                }
                else
                {
                    units[i] = new RangedUnit(x, y, factions[factionIndex]);
                }
                map[x, y] = units[i].Faction[0] + "/" + units[i].Symbol;
            }
        }

        private void initializeBuildings()
        {
            for (int i = 0; i < building.Length; i++)
            {
                int x = rand.Next(0, mapSize);
                int y = rand.Next(0, mapSize);
                int factionIndex = rand.Next(0, 2);
                int buildingtype = rand.Next(0, 2);

                while (map[x, y] != null)
                {
                    x = rand.Next(0, mapSize);
                    y = rand.Next(0, mapSize);
                }

                if (buildingtype == 0)
                {
                    building[i] = new ResourceBuilding(rand.Next(x,mapSize),rand.Next(y,mapSize),"A-TEAM", "V");
                }
                else
                {
                    building[i] = new FactoryBuilding(rand.Next(y,mapSize),rand.Next(x,mapSize),"B-TEAM", "F");
                }
                map[x, y] = building[i].Faction[0] + "/" + building[i].Symbol;
            }

            
        }

       



        //public void GetMap()
        //{
        //    for (int y = 0; y < 20; y++)
        //    {
        //        for(int x = 0; x < 20; x++)
        //        {
        //            GameMap[y, x] = " ";
        //        }
        //    }
        //}

        //public void PopulateMap()
        //{
        //    SpawnUnits();

        //    for(int k = 0; k < units.Length; k++)
        //    {
        //        Console.WriteLine(units[k].ToString());
        //    }

        //}

        //    public void SpawnUnits()
        //    {
        //        for (int k = 0; k < units.Length; k++)
        //        {
        //            int Type;
        //            int Faction;
        //            int name = rnd.Next(0, Names.Length);

        //            string myFaction = "";
        //            string mySymbol = "";
        //            int x = rnd.Next(1, 20);
        //            int y = rnd.Next(1, 20);

        //            Type = rnd.Next(1, 3);

        //            switch (Type)
        //            {
        //                case 1:
        //                    Faction = rnd.Next(1, 3);

        //                    switch (Faction)
        //                    {
        //                        case 1:
        //                            myFaction = "Gold Team";
        //                            mySymbol = "M";
        //                            break;
        //                        case 2:
        //                            myFaction = "Silver Team";
        //                            mySymbol = "m";
        //                            break;
        //                    }
        //                    units[k] = new MeleeUnit(x, y, myFaction, mySymbol, Names[name]);
        //                    break;

        //                case 2:
        //                    Faction = rnd.Next(1, 3);

        //                    switch (Faction)
        //                    {
        //                        case 1:
        //                            myFaction = "Gold Team";
        //                            mySymbol = "R";
        //                            break;
        //                        case 2:
        //                            myFaction = "Silver Team";
        //                            mySymbol = "r";
        //                            break;
        //                    }
        //                    units[k] = new MeleeUnit(x, y, myFaction, mySymbol, Names[name]);
        //                    break;
        //            }
        //            GameMap[units[k].YPosition, units[k].XPosition] = units[k].Symbol;            
        //        }
        //    }
    }
}
