using System.Windows.Forms;

namespace FourInRowWindowsApp
{
    internal class FormGame : Form
    {
        internal static int s_Row;
        internal static int s_Column;
        internal static string s_PlayerOneName;
        internal static string s_PlayerTwoName;
        private Button[,] m_BodyButtons;
        private Button[] m_TitleButtons;
        private Board m_Board;
        private Player s_PlayerOne;
        private Player s_PlayerTwo;
        private int s_ColumnChoosen;
        private bool m_PlayerOnePlay = true;

        internal FormGame()
        {
            this.Text = "Four in row !!";
            m_Board = new Board(s_Row, s_Column);
            m_BodyButtons = new Button[s_Row, s_Column];
            m_TitleButtons = new Button[s_Column];
        }

        internal void RunGame()
        {
            GameManager.setIsHuman(s_PlayerTwoName);
            s_PlayerOne = new Player(1, true, 0);
            s_PlayerTwo = new Player(2, GameManager.s_IsHuman, 0);
            CreateBoard();
            this.ShowDialog();
        }

        internal void CreateBoard()
        {
            int top = 0;
            int left = 0;

            for (int columnIndex = 0; columnIndex < s_Column; columnIndex++)
            {
                Button button = new Button();
                button.Width = 60;
                button.Text = (columnIndex + 1).ToString();
                button.Top = top;
                button.Left = left;
                m_TitleButtons[columnIndex] = button;
                button.Click += Button_Click;
                this.Controls.Add(button);
                left += 65;
            }

            left = 0;
            top = 30;

            for (int rowIndex = 0; rowIndex < s_Row; rowIndex++)
            {
                left = 0;
                for (int columnIndex = 0; columnIndex < s_Column; columnIndex++)
                {
                    Button button = new Button();
                    button.Width = 60;
                    button.Text = string.Empty;
                    button.Top = top;
                    button.Left = left;
                    this.Controls.Add(button);
                    m_BodyButtons[rowIndex, columnIndex] = button;
                    left += 65;
                }
                top += 30;
            }

            Label playerOneNameAndPoints = new Label();
            playerOneNameAndPoints.Text = string.Format("{0} : {1}", s_PlayerOneName, s_PlayerOne.numberOfPoints);
            playerOneNameAndPoints.Left = left / 2 - 60;
            playerOneNameAndPoints.Top = top + 20;
            playerOneNameAndPoints.Width = 80;
            this.Controls.Add(playerOneNameAndPoints);
            Label playerTwoNameAndPoints = new Label();
            playerTwoNameAndPoints.Text = string.Format("{0} : {1}", s_PlayerTwoName, s_PlayerTwo.numberOfPoints);
            playerTwoNameAndPoints.Left = left / 2 + 40;
            playerTwoNameAndPoints.Top = top + 20;
            playerTwoNameAndPoints.Width = 80;
            this.Controls.Add(playerTwoNameAndPoints);
            this.Height = top + 80;
            this.Width = left + 35;
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            s_ColumnChoosen = int.Parse((sender as Button).Text);

            if (!GameManager.s_IsHuman)
            {
                s_PlayerOne.PlayYourTurn(m_Board, 1, s_ColumnChoosen);
                setButtonText();
                checkIfPlayerWin(1);
                if (GameManager.BoardFull(m_Board))
                {
                    //tie massage
                    messageBox("A Tie", string.Format("Tie!! {0}Another Round?", System.Environment.NewLine));
                }
                s_PlayerTwo.PlayYourTurn(m_Board, 2, s_ColumnChoosen);
                setButtonText();
                checkIfPlayerWin(2);
            }
            else if (m_PlayerOnePlay)
            {
                s_PlayerOne.PlayYourTurn(m_Board, 1, s_ColumnChoosen);
                setButtonText();
                checkIfPlayerWin(1);
                m_PlayerOnePlay = false;
            }
            else
            {
                s_PlayerTwo.PlayYourTurn(m_Board, 2, s_ColumnChoosen);
                setButtonText();
                checkIfPlayerWin(2);
                m_PlayerOnePlay = true;
            }

            if (GameManager.ColumnIsFull(s_ColumnChoosen - 1, m_Board))
            {
                (sender as Button).Enabled = false;
            }
            if (GameManager.ColumnIsFull(GameManager.s_LastColumnMove, m_Board))
            {
                m_TitleButtons[GameManager.s_LastColumnMove].Enabled = false;
            }
            if (GameManager.BoardFull(m_Board))
            {
                //tie massage
                messageBox("A Tie", string.Format("Tie!! {0}Another Round?", System.Environment.NewLine));
            }
        }

        private void setButtonText()
        {
            for (int rowIndex = 0; rowIndex < s_Row; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < s_Column; columnIndex++)
                {
                    m_BodyButtons[rowIndex, columnIndex].Text = m_Board.gameBoard[rowIndex, columnIndex].ToString();
                }
            }
        }

        private void checkIfPlayerWin(int player)
        {
            if (GameManager.CheckIfWin(m_Board))
            {
                if(player == 1)
                {
                    s_PlayerOne.AddOnePoint();
                    //// massegePlayerOneWin;
                    messageBox("A Win!", string.Format("{0} Won!{1}Another Round?", s_PlayerOneName, System.Environment.NewLine));
                }
                else
                {
                    s_PlayerTwo.AddOnePoint();
                    // massegePlayerTwoWin;
                    messageBox("A Win!", string.Format("{0} Won!{1}Another Round?", s_PlayerTwoName, System.Environment.NewLine));
                }
            }
        }

        private void messageBox(string i_Caption, string i_Message)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(i_Message, i_Caption, buttons);

            if (result == DialogResult.No)
            {
                this.Close();
            }
            else
            {
                this.Hide();
                this.Controls.Clear();
                m_Board.ClearBoard();
                CreateBoard();
                this.Show();
            }
        }
    }
}