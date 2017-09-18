using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FINALS_OOPL
{
    class CALCFUNCTIONS : Form1
    {
        static string connectionString = "server=localhost;user=root;pass=;database=calculatorgame;";
        MySqlConnection connect = new MySqlConnection(connectionString);
        static Parser calc = new Parser();
        public bool openConnection()
        {
            try
            {
                connect.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool closeConnection()
        {
            try
            {
                connect.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void loadButtons(ref TextBox txtBox, ref Button btn1, ref Button btn2, ref Button btn3, ref Button btn4, ref Button btn5, ref Button btn6, ref Button btn7, ref Button btn8, ref Button btn9, ref int currentLevel, ref int currentNoMoves, ref int currentGoal, ref Label moves, ref Label level, ref Label goal)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM gamelevels";
            MySqlDataReader reader;
            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (int.Parse(reader["gameLev"].ToString()) == currentLevel)
                    {
                        disableMainButtons(ref btn1, ref btn2, ref btn3, ref btn4, ref btn5, ref btn6, ref btn7, ref btn8, ref btn9);
                        moves.Text = "Moves : " + reader["noOfMoves"].ToString();
                        currentNoMoves = int.Parse(reader["noOfMoves"].ToString());
                        level.Text = "Level : " + reader["gameLev"].ToString();
                        goal.Text = "Goal : " + reader["goal"].ToString();
                        currentGoal = int.Parse(reader["goal"].ToString());
                        btn1.Text = reader["button1"].ToString();
                        btn2.Text = reader["button2"].ToString();
                        btn3.Text = reader["button3"].ToString();
                        btn4.Text = reader["button4"].ToString();
                        btn5.Text = reader["button5"].ToString();
                        btn6.Text = reader["button6"].ToString();
                        btn7.Text = reader["button7"].ToString();
                        btn8.Text = reader["button8"].ToString();
                        btn9.Text = reader["button9"].ToString();
                        txtBox.Text = reader["startVal"].ToString();
                        enableMainButtons(ref btn1, ref btn2, ref btn3, ref btn4, ref btn5, ref btn6, ref btn7, ref btn8, ref btn9);
                    }
                    }
                }
        }

        public void enableMainButtons(ref Button btn1, ref Button btn2, ref Button btn3, ref Button btn4, ref Button btn5, ref Button btn6, ref Button btn7, ref Button btn8, ref Button btn9)
        {
            if (btn1.Text != "")
            {
                btn1.Enabled = true;
            }
            if (btn2.Text != "")
            {
                btn2.Enabled = true;
            }
            if (btn3.Text != "")
            {
                btn3.Enabled = true;
            }
            if (btn4.Text != "")
            {
                btn4.Enabled = true;
            }
            if (btn5.Text != "")
            {
                btn5.Enabled = true;
            }
            if (btn6.Text != "")
            {
                btn6.Enabled = true;
            }
            if (btn7.Text != "")
            {
                btn7.Enabled = true;
            }
            if (btn8.Text != "")
            {
                btn8.Enabled = true;
            }
            if (btn9.Text != "")
            {
                btn9.Enabled = true;
            }
        }

        public void disableMainButtons(ref Button btn1, ref Button btn2, ref Button btn3, ref Button btn4, ref Button btn5, ref Button btn6, ref Button btn7, ref Button btn8, ref Button btn9)
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
        }

        public void mdasButton(ref Button btn, ref TextBox txtNumber, ref int currentNoMoves, ref Label lblMoves)
        {
            --currentNoMoves;
            string eq = txtNumber.Text + btn.Text;
            double num = calc.evaluate(eq);
            txtNumber.Text = "" + num;
            lblMoves.Text = "Moves : "+currentNoMoves;
        }

        public bool checkDecimal(ref TextBox txtNumber)
        {
            int i = 0;
            while (i < txtNumber.Text.Length)
            {
                if (txtNumber.Text[i] == '.')
                {
                    return true;
                }
                i++;
            }

            return false;
        }

        public double displayScore(int i, int currentlevel)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "SELECT * FROM gamelevels";
            MySqlDataReader reader;

            using (reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader["gameLev"].ToString() == currentLevel.ToString())
                    {
                        double score = int.Parse(reader["score"].ToString()) - i;
                        return score;
                    }
                }
            }

            return 0;
        }

        public void updatingScores()
        {

        }
    }
}
