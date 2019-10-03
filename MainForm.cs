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
    public partial class FrmMain : Form
    {
        GameEngine engine;
        Timer timer;
        GameState gameState = GameState.PAUSED;


        public FrmMain()
        {
            InitializeComponent();
            engine = new GameEngine();
            UpdateUI();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += TimerTick;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TimerTick(object sender, EventArgs e)
        {
            engine.GameLoop();
            UpdateUI();

            if (engine.IsGameOver)
            {
                timer.Stop();
                UpdateUI();
                lblMap.Text = engine.WinningFaction + " WON!\n" + lblMap.Text;
                gameState = GameState.ENDED;
                btnStart.Text = "RESTART";
            }
        }

        private void UpdateUI()
        {
            lblMap.Text = engine.MapDisplay;
            lblRoundCount.Text = "Round: " + engine.Round;
            rtbUnitInfo.Text = engine.GetUnitInfo();
            rtbBuildingInfo.Text = engine.GetBuildingsInfo();
            lblUnits.Text = "Units (" + engine.NumUnits + ")";
            lblBuildings.Text = "Buildings (" + engine.NumBuildings + ")";
        }




       

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (gameState == GameState.RUNNING)
            {
                timer.Stop();
                gameState = GameState.PAUSED;
                btnStart.Text = "START";
            }

            else
            {
                if (gameState == GameState.ENDED)
                {
                    engine.Reset();
                }
                timer.Start();
                gameState = GameState.RUNNING;
                btnStop.Text = "PAUSE";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            engine.SaveGame();
            lblMap.Text = "GAME SAVED\n" + lblMap.Text;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            engine.LoadGame();
            lblMap.Text = "GAME LOADED\n" + engine.MapDisplay;
        }

        public enum GameState
        {
            RUNNING,
            PAUSED,
            ENDED
        }
    }
}
