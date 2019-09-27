using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_POE_Part_2
{
    class GameEngine
    {
        Map map;
        
        bool isGamover = false;
        string winningfaction = "";
        int round = 0;

        public GameEngine()
        {
            map = new Map(10,10);  
            
           
        }

        public bool isGameover
        {
            get { return isGamover; }
        }

        public string WinningFaction
        {
            get { return winningfaction; }
        }

        public int Round
        {
            get { return round; }
        }

        public string GetMapDisplay()
        {
            return map.GetMapDisplay();
        }

        public string GetUnitUnfo()
        {
            string unitInfo = "";
           
            foreach( Unit unit in map.Units)
            {
                unitInfo += unit + "\n";
            }


            return unitInfo;
        }

        
        public string GetBuildUnfo()
        {
            string buildInfo = "";

            foreach (Building build in map.build)
            {
                buildInfo += build + "\n";
            }


            return buildInfo;
        }




        public void Reset()
        {
            map.Reset();
            isGamover = false;
            round = 0;
        }

        public void GameLoop()
        {
            foreach(Unit unit in map.Units)
            {
                if(unit.IsDestroyed)
                {
                    continue;
                }

                Unit closestUnit = unit.GetClosestUnit(map.Units);
                if(closestUnit ==null)
                {
                    isGamover = true;
                    winningfaction = unit.Faction;
                    map.updateMap();
                    return;
                }

                double healthpercentage = unit.Hp / unit.MaxHp;
                if(healthpercentage <= 0.25)
                {
                    unit.RunAway();
                }
                else if(unit.InRange(closestUnit))
                {
                    unit.Attack(closestUnit);
                }
                else
                {
                    unit.Move(closestUnit);
                }
                stayinBounds(unit, map.Size);
            }
            
            

            map.updateMap();
            round++;
            
        }



        private void stayinBounds(Unit unit, int size)
        {
            if(unit.XPosition< 0)
            {
                unit.XPosition = 0;
            }
            else if(unit.XPosition >= size)
            {
                unit.XPosition = size - 1;
            }

            if(unit.YPosition < 0)
            {
                unit.YPosition = 0;
            }
            else if(unit.YPosition >= size)
            {
                unit.YPosition = size - 1;
            }


            
        }

        public string saveString()
        {
            return map.Units.ToString();
        }

        public void Save()
        {
            FileStream saveUnits = new FileStream("unit.txt", FileMode.Open, FileAccess.Write);
            StreamWriter save = new StreamWriter(saveUnits);
            save.WriteLine(saveString());
            save.Close();
            saveUnits.Close();
        }
       



        //public void PlayGame()
        //{

        //}

    }
    
       

    
}
