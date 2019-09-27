using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE_POE_Part_2
{
    public partial class Form1 : Form
    {
        GameEngine engine;

        Timer timer;
        Gamestate gamestate = Gamestate.PAUSED;
       
        
        public Form1()
        {
            InitializeComponent();

            engine = new GameEngine();
            lblMap.Text = engine.GetMapDisplay();
           
            rtbUnitInfo.Text = engine.GetUnitUnfo();
            cmbBuild.Text = engine.GetBuildUnfo();
            lblRoundCount.Text = " Round: " + engine.Round;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer2_Tick;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            engine.GameLoop();
            UpdateUI();

            
            if (engine.isGameover)
            {
                timer.Stop();
                lblMap.Text = engine.WinningFaction + " WON!\n" + lblMap.Text;
                gamestate = Gamestate.ENDED;
                btnStart.Text = "Restart";
            }
        }

        private void UpdateUI()
        {
           
            lblMap.Text = engine.GetMapDisplay();
          
            rtbUnitInfo.Text = engine.GetUnitUnfo();
            cmbBuild.Text = engine.GetBuildUnfo();

            lblRoundCount.Text = "Round:" + engine.Round;
            
        }

        public enum Gamestate
        {
            RUNNING,
            PAUSED,
            ENDED
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(gamestate == Gamestate.RUNNING)
            {
                timer.Stop();
                gamestate = Gamestate.PAUSED;
                btnStart.Text = "Start";
            }
            else
            {
                if(gamestate == Gamestate.ENDED)
                {
                    engine.Reset();
                }
                timer.Start();
                gamestate = Gamestate.RUNNING;
                btnStart.Text = "Pause";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GameEngine game = new GameEngine();
            game.Save();
        }

        





    }
}
