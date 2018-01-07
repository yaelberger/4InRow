using System;
using System.Windows.Forms;

namespace FourInRowWindowsApp
{
    internal class FormGameSettings : Form
    {
        internal TextBox m_TextBoxPlayer1 = new TextBox();
        internal TextBox m_TextBoxPlayer2 = new TextBox();
        internal CheckBox m_CheckBox = new CheckBox();
        internal NumericUpDown m_Row = new NumericUpDown();
        internal NumericUpDown m_Col = new NumericUpDown();

        internal FormGameSettings()
        {
            this.Text = "Game Settings";
            this.m_TextBoxPlayer1.Left = 140;
            this.m_TextBoxPlayer1.Top = 35;
            this.m_TextBoxPlayer2.Name = "player Two Check Box";
            this.m_TextBoxPlayer2.Left = 140;
            this.m_TextBoxPlayer2.Top = 60;
            this.m_TextBoxPlayer2.Text = "[Computer]";
            this.m_TextBoxPlayer2.Enabled = false;
            this.m_CheckBox.Left = 20;
            this.m_CheckBox.Top = 60;
            this.m_CheckBox.Click += CheckBox_Click;
            this.m_Row.Height = 150;
            this.m_Row.Width = 40;
            this.m_Row.Top = 135;
            this.m_Row.Left = 70;
            this.m_Row.Minimum = 4;
            this.m_Row.Maximum = 8;
            this.m_Col.Height = 150;
            this.m_Col.Width = 40;
            this.m_Col.Top = 135;
            this.m_Col.Left = 175;
            this.m_Col.Minimum = 4;
            this.m_Col.Maximum = 8;

            Label playersText = new Label();
            playersText.Text = "Players:";
            playersText.Left = 10;
            playersText.Top = 10;

            Label player1Text = new Label();
            player1Text.Text = "Player 1:";
            player1Text.Left = 20;
            player1Text.Top = 35;

            Label player2Text = new Label();
            player2Text.Text = "Player 2:";
            player2Text.Left = 40;
            player2Text.Top = 65;

            Label boardSizeText = new Label();
            boardSizeText.Text = "Board Size:";
            boardSizeText.Width = 70;
            boardSizeText.Top = 110;
            boardSizeText.Left = 20;

            Label rowsText = new Label();
            rowsText.Text = "Rows:";
            rowsText.Width = 40;
            rowsText.Top = 137;
            rowsText.Left = 25;

            Label colText = new Label();
            colText.Text = "Cols:";
            colText.Width = 40;
            colText.Top = 137;
            colText.Left = 130;

            Button startButton = new Button();
            startButton.Text = "Start!";
            startButton.Top = 180;
            startButton.Left = 20;
            startButton.Width = 220;
            startButton.Click += StartButton_Click;

            this.Controls.Add(playersText);
            this.Controls.Add(player1Text);
            this.Controls.Add(player2Text);
            this.Controls.Add(m_TextBoxPlayer1);
            this.Controls.Add(m_TextBoxPlayer2);
            this.Controls.Add(boardSizeText);
            this.Controls.Add(rowsText);
            this.Controls.Add(m_Row);
            this.Controls.Add(colText);
            this.Controls.Add(m_Col);
            this.Controls.Add(m_CheckBox);
            this.Controls.Add(startButton);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            FormGame.s_PlayerOneName = m_TextBoxPlayer1.Text;
            if (m_CheckBox.Checked)
            {
                FormGame.s_PlayerTwoName = m_TextBoxPlayer2.Text;
            }
            else
            {
                FormGame.s_PlayerTwoName = "Computer";
            }
            FormGame.s_Row = (int)m_Row.Value;
            FormGame.s_Column = (int)m_Col.Value;
            this.Close();
        }

        private void CheckBox_Click(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                m_TextBoxPlayer2.Enabled = true;
                m_TextBoxPlayer2.Text = string.Empty;
            }
            else
            {
                m_TextBoxPlayer2.Enabled = false;
                m_TextBoxPlayer2.Text = "[Computer]";
            }
        }
    }
}
