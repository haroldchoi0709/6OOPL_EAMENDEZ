using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINALS_OOPL
{
    public partial class Form1 : Form
    {
        static CALCFUNCTIONS func = new CALCFUNCTIONS();
        public int currentLevel = 1;
        public int currentNoMoves = 0;
        public int currentGoal = 0;
        public double currentScore = 0;
        public string name = "";
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (func.openConnection() == true)
            {
                MessageBox.Show("Welcome!");
                panel2.Hide();
            }
            else
            {
                MessageBox.Show("Connection Failed.");
                Application.Exit();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            func.loadButtons(ref txtNumber,ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
            lblTime.Text = "Time : 0 sec";
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text != "")
            {
                func.mdasButton(ref button1,ref txtNumber,ref currentNoMoves, ref lblMoves);
                if (txtNumber.Text == currentGoal.ToString())
                {
                    timer1.Stop();
                    currentScore = i > 5 ? func.displayScore(i, currentLevel) : 100;
                    MessageBox.Show("Score = "+currentScore);
                    ++currentLevel;
                    func.loadButtons(ref txtNumber, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                    i = 0;
                    lblTime.Text = "Time : 0 sec";
                    timer1.Start();
                }
                else if (currentNoMoves == 0)
                {
                    MessageBox.Show("Out of moves");
                    func.loadButtons(ref txtNumber, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                }
            }          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            func.loadButtons(ref txtNumber, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text != "")
            {
                func.mdasButton(ref button2, ref txtNumber, ref currentNoMoves, ref lblMoves);
                if (txtNumber.Text == currentGoal.ToString())
                {
                    timer1.Stop();
                    currentScore = i > 5 ? func.displayScore(i, currentLevel) : 100;
                    MessageBox.Show("Score = " + currentScore);
                    ++currentLevel;
                    func.loadButtons(ref txtNumber, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                    i = 0;
                    lblTime.Text = "Time : 0 sec";
                    timer1.Start();
                }
                else if (currentNoMoves == 0)
                {
                    MessageBox.Show("Out of moves");
                    func.loadButtons(ref txtNumber, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text != "")
            {
                func.mdasButton(ref button4, ref txtNumber, ref currentNoMoves, ref lblMoves);
                if (txtNumber.Text == currentGoal.ToString())
                {
                    timer1.Stop();
                    currentScore = i > 5 ? func.displayScore(i, currentLevel) : 100;
                    MessageBox.Show("Score = " + currentScore);
                    ++currentLevel;
                    func.loadButtons(ref txtNumber, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                    i = 0;
                    lblTime.Text = "Time : 0 sec";
                    timer1.Start();
                }
                else if (currentNoMoves == 0)
                {
                    MessageBox.Show("Out of moves");
                    func.loadButtons(ref txtNumber, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
                }
            }
        }

        private void txtNumber_TextChanged(object sender, EventArgs e)
        {
            if (func.checkDecimal(ref txtNumber))
            {
                MessageBox.Show("Decimal Recieved");
                func.loadButtons(ref txtNumber, ref button1, ref button2, ref button3, ref button4, ref button5, ref button6, ref button7, ref button8, ref button9, ref currentLevel, ref currentNoMoves, ref currentGoal, ref lblMoves, ref lblLevel, ref lblGoal);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            lblTime.Text = "Time : " + i.ToString()+" sec";
        }
    }
}
