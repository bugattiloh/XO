using System;
using System.Windows.Forms;

namespace XO
{
    public partial class Form1 : Form
    {
        int[] values = new int[9];
        int player = 1;
        bool playing = true;

        public Form1()
        {
            InitializeComponent();

            PrintToButtons();
        }

        void SwitchPlayer()
        {
            player *= -1;
        }

        private void Turn_Click(object sender, EventArgs e)
        {
            if (!playing)
            {
                return;
            }
            Button b = sender as Button;
            int number = int.Parse(b.Name.Substring("button".Length)) - 1;
            if (values[number] != 0)
            {
                MessageBox.Show("This place is occupied");
                return;
            }
            values[number] = player;
            PrintToButtons();

            if (Checkwin() != 0)
            {
                playing = false;
                MessageBox.Show(Checkwin().ToString());
                ResetGame();
                return;
            }

            if (HasFree())
            {
                SwitchPlayer();
            }
            else
            {
                MessageBox.Show("No place left");
                playing = false;
            }
        }

        private bool HasFree()
        {
            for (int i = 0; i < 9; i++)
            {
                if (values[i] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private int Checkwin()
        {
            int line1Sum = values[0] + values[1] + values[2];
            int line2Sum = values[3] + values[4] + values[5];
            int line3Sum = values[6] + values[7] + values[8];

            int column1Sum = values[0] + values[3] + values[6];
            int column2Sum = values[1] + values[4] + values[7];
            int column3Sum = values[2] + values[5] + values[8];

            int diag1Sum = values[0] + values[4] + values[8];
            int diag2Sum = values[2] + values[4] + values[6];


            if (line1Sum == 3 || line2Sum == 3 || line3Sum == 3
                || column1Sum == 3 || column2Sum == 3 || column3Sum == 3
                || diag1Sum == 3 || diag2Sum == 3)
            {
                return 1;
            }
            if (line1Sum == -3 || line2Sum == -3 || line3Sum == -3
                || column1Sum == -3 || column2Sum == -3 || column3Sum == -3
                || diag1Sum == -3 || diag2Sum == -3)
            {
                return -1;
            }
            return 0;
        }

        private void ResetGame()
        {
            player = 1;
            for (int i = 0; i < 9; i++)
            {
                values[i] = 0;
            }
            PrintToButtons();
        }

        char IntToChar(int n)
        {
            if (n == -1)
            {
                return 'O';
            }
            else if (n == 1)
            {
                return 'X';
            }
            return ' ';
        }

        private void PrintToButtons()
        {
            button1.Text = IntToChar(values[0]).ToString();
            button2.Text = IntToChar(values[1]).ToString();
            button3.Text = IntToChar(values[2]).ToString();
            button4.Text = IntToChar(values[3]).ToString();
            button5.Text = IntToChar(values[4]).ToString();
            button6.Text = IntToChar(values[5]).ToString();
            button7.Text = IntToChar(values[6]).ToString();
            button8.Text = IntToChar(values[7]).ToString();
            button9.Text = IntToChar(values[8]).ToString();

            button1.Enabled = values[0] == 0;
            button2.Enabled = values[1] == 0;
            button3.Enabled = values[2] == 0;
            button4.Enabled = values[3] == 0;
            button5.Enabled = values[4] == 0;
            button6.Enabled = values[5] == 0;
            button7.Enabled = values[6] == 0;
            button8.Enabled = values[7] == 0;
            button9.Enabled = values[8] == 0;
        }
    }
}
