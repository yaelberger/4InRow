using System;

namespace FourInRowWindowsApp
{
    internal class Player
    {
        private static int s_ColumnWin;
        private bool m_IsHuman = false;
        private int m_NumberOfPoints;
        private ePlayerSign m_PlayerSign;

        internal Player(int i_PlayerNumber, bool i_IsHuman, int i_NumberOfPoints)
        {
            if (i_PlayerNumber == 1)
            {
                m_PlayerSign = ePlayerSign.PlayerOneSign;
            }
            else
            {
                m_PlayerSign = ePlayerSign.PlayerTwoSign;
            }

            this.m_IsHuman = i_IsHuman;
            this.numberOfPoints = numberOfPoints;
        }

        internal bool isHuman
        {
            get
            {
                return m_IsHuman;
            }
        }

        internal int numberOfPoints
        {
            get
            {
                return m_NumberOfPoints;
            }

            set
            {
                m_NumberOfPoints = value;
            }
        }

        internal enum ePlayerSign
        {
            PlayerOneSign = 'X',
            PlayerTwoSign = 'O',
            Empty = ' ',
        }

        private void computerTrun(Board i_Board)
        {
            bool isWin = checkIfComputerCanWinOrBlock(i_Board, (char)m_PlayerSign);
            bool canBlock = false;

            if (isWin)
            {
                GameManager.MakeMove((char)m_PlayerSign, s_ColumnWin, i_Board);
            }
            else
            {
                canBlock = checkIfComputerCanWinOrBlock(i_Board, (char)ePlayerSign.PlayerOneSign);
                if (canBlock)
                {
                    GameManager.MakeMove((char)m_PlayerSign, s_ColumnWin, i_Board);
                }
            }

            if (!isWin && !canBlock)
            {
                Random rnd = new Random();
                int randomColumn = rnd.Next(1, i_Board.numberOfColumn + 1);
                while (GameManager.ColumnIsFull(randomColumn - 1, i_Board))
                {
                    randomColumn = rnd.Next(1, i_Board.numberOfColumn + 1);
                }

                GameManager.MakeMove((char)m_PlayerSign, randomColumn, i_Board);
            }
        }

        private bool checkIfComputerCanWinOrBlock(Board i_Board, char sign)
        {
            bool isWin = false;
            int columnIndex = 1;

            while (columnIndex <= i_Board.numberOfColumn)
            {
                if (GameManager.ColumnIsFull(columnIndex - 1, i_Board))
                {
                    columnIndex++;
                }
                else
                {
                    GameManager.MakeMove(sign, columnIndex, i_Board);

                    if (GameManager.CheckIfWin(i_Board))
                    {
                        isWin = true;
                        GameManager.DeleteLastMove(i_Board);
                        s_ColumnWin = columnIndex;
                        break;
                    }
                    else
                    {
                        columnIndex++;
                        GameManager.DeleteLastMove(i_Board);
                    }
                }
            }

            return isWin;
        }

        internal void PlayYourTurn(Board io_Board, int i_NumberOfPlayer, int columnChoosen)
        {
            if (!m_IsHuman)
            {
                computerTrun(io_Board);
            }
            else
            {
                if (GameManager.CheckIfQ(columnChoosen))
                {
                    GameManager.s_IsQ = true;
                }
                else
                { 
                    GameManager.MakeMove((char)m_PlayerSign, columnChoosen, io_Board);
                }
            }
        }

        internal void AddOnePoint()
        {
            m_NumberOfPoints++;
        }
    }
}