namespace FourInRowWindowsApp
{
    public class GameManager
    {
        private static int s_LastRowMove;
        internal static int s_LastColumnMove;
        internal static bool s_IsQ = false;
        internal static bool s_IsHuman = false;

        internal static bool ColumnIsFull(int i_ColumnChoosed, Board i_Board)
        {
            bool isFull = false;
            if(i_Board.gameBoard[0, i_ColumnChoosed] != ' ')
            {
                isFull = true;
            }

            return isFull;
        }

        internal static bool CheckIfWin(Board i_Board)
        {
            bool isWin = false;
            if(checkIfFourInColumn(i_Board) || checkIfFourInRow(i_Board) || checkIfFourInSlant(i_Board))
            {
                isWin = true;
            }
           
            return isWin;
        }

        internal static bool CheckIfQ(int columnChoosen)
        {
            bool isQ = false;
            if(columnChoosen == 0)
            {
                isQ = true;
            }

            return isQ;
        }

        private static bool checkIfFourInColumn(Board i_Board)
        {
            bool isFourInColumn = false;
            int countSigns = 1;
            char sign = i_Board.gameBoard[s_LastRowMove, s_LastColumnMove];
            int rowToCheckDown = s_LastRowMove - 1;
            int rowToCheckUp = s_LastRowMove + 1;

            while (rowToCheckDown > -1 && countSigns != 4 )
            {
                if (sign == i_Board.gameBoard[rowToCheckDown, s_LastColumnMove])
                {
                    countSigns++;
                    rowToCheckDown--;
                }
                else
                {
                    break;
                }
            }

            while (rowToCheckUp < i_Board.numberOfRow && countSigns != 4)
            {
                if (sign == i_Board.gameBoard[rowToCheckUp, s_LastColumnMove])
                {
                    countSigns++;
                    rowToCheckUp++;
                }
                else
                {
                    break;
                }
            }
            
            if (countSigns == 4)
            {
                isFourInColumn = true;
            }

            return isFourInColumn;
        }

        private static bool checkIfFourInRow(Board i_Board)
        {
            bool isFourInRow = false;
            int countSigns = 1;
            char sign = i_Board.gameBoard[s_LastRowMove, s_LastColumnMove];
            int columnToCheckDown = s_LastColumnMove - 1;
            int columnToCheckUp = s_LastColumnMove + 1;

            while (columnToCheckDown > -1 && countSigns != 4)
            {
                if (sign == i_Board.gameBoard[s_LastRowMove, columnToCheckDown])
                {
                    countSigns++;
                    columnToCheckDown--;
                }
                else
                {
                    break;
                }
            }

            while (columnToCheckUp < i_Board.numberOfColumn && countSigns != 4)
            {
                if (sign == i_Board.gameBoard[s_LastRowMove, columnToCheckUp])
                {
                    countSigns++;
                    columnToCheckUp++;
                }
                else
                {
                    break;
                }
            }

            if (countSigns == 4)
            {
                isFourInRow = true;
            }

            return isFourInRow;
        }

        private static bool checkIfFourInSlant(Board i_Board)
        {
            bool isFourInSlant = false;
            char sign = i_Board.gameBoard[s_LastRowMove, s_LastColumnMove];
            int rowToCheckDown = s_LastRowMove - 1;
            int columnToCheckDown = s_LastColumnMove - 1;
            int rowToCheckUp = s_LastRowMove + 1;
            int columnToCheckUp = s_LastColumnMove + 1;

            int counterSigns = 1;

            while (Board.CheckIfBoardIndexIsValid(rowToCheckDown, columnToCheckDown, i_Board) && counterSigns != 4)
            {
                if (sign == i_Board.gameBoard[rowToCheckDown, columnToCheckDown])
                {
                    counterSigns++;
                    rowToCheckDown--;
                    columnToCheckDown--;
                }
                else
                {
                    break;
                }
            }

            while (Board.CheckIfBoardIndexIsValid(rowToCheckUp, columnToCheckUp, i_Board) && counterSigns != 4)
            {
                if (sign == i_Board.gameBoard[rowToCheckUp, columnToCheckUp])
                {
                    counterSigns++;
                    rowToCheckUp++;
                    columnToCheckUp++;
                }
                else
                {
                    break;
                }
            }

            if(counterSigns == 4)
            {
                isFourInSlant = true;
            }

            counterSigns = 1;
            rowToCheckDown = s_LastRowMove - 1;
            columnToCheckUp = s_LastColumnMove + 1;
            rowToCheckUp = s_LastRowMove + 1;
            columnToCheckDown = s_LastColumnMove - 1;

            while (Board.CheckIfBoardIndexIsValid(rowToCheckDown, columnToCheckUp, i_Board) && counterSigns != 4 && !isFourInSlant)
            {
                if (sign == i_Board.gameBoard[rowToCheckDown, columnToCheckUp])
                {
                    counterSigns++;
                    rowToCheckDown--;
                    columnToCheckUp++;
                }
                else
                {
                    break;
                }
            }

            while (Board.CheckIfBoardIndexIsValid(rowToCheckUp, columnToCheckDown, i_Board) && counterSigns != 4 && !isFourInSlant)
            {
                if (sign == i_Board.gameBoard[rowToCheckUp, columnToCheckDown])
                {
                    counterSigns++;
                    rowToCheckUp++;
                    columnToCheckDown--;
                }
                else
                {
                    break;
                }
            }

            if (counterSigns == 4)
            {
                isFourInSlant = true;
            }

            return isFourInSlant;
        }

        internal static void MakeMove(char i_PlayerSign, int i_ColumChoosen, Board i_Board)
        {
                int maxRowPossible = i_Board.numberOfRow;

                while (i_Board.gameBoard[maxRowPossible - 1, i_ColumChoosen - 1] != ' ')
                {
                    maxRowPossible--;
                }

                i_Board.gameBoard[maxRowPossible - 1, i_ColumChoosen - 1] = i_PlayerSign;

                s_LastRowMove = maxRowPossible - 1;
                s_LastColumnMove = i_ColumChoosen - 1;
            }

        ////check only the first row
        internal static bool BoardFull(Board i_Board)
        {
            bool isFull = true;
            int columnIndex = 0;
            while (columnIndex < i_Board.numberOfColumn)
            {
                if (i_Board.gameBoard[0, columnIndex] == ' ')
                {
                    isFull = false;
                    break;
                }

                columnIndex++;
            }

            return isFull;
        }

        internal static void DeleteLastMove(Board i_Board)
        {
            i_Board.Delete(s_LastRowMove, s_LastColumnMove);
        }

        internal static void setIsHuman(string i_Name)
        {
            if (char.Equals(i_Name, "Computer"))
            {
                s_IsHuman = false;
            }
            else
            {
                s_IsHuman = true;
            }
        }
    }
}