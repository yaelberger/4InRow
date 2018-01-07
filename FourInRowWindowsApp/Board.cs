namespace FourInRowWindowsApp
{
    internal class Board
    {
        private readonly char[,] r_GameBoard;
        private readonly int r_NumberOfRow;
        private readonly int r_NumberOfColumn;

        internal static bool CheckIfBoardIndexIsValid(int i_Row, int i_Column, Board i_Board)
        {
            bool isValid = false;

            if (i_Row > -1 && i_Row < i_Board.numberOfRow && i_Column > -1 && i_Column < i_Board.numberOfColumn)
            {
                isValid = true;
            }

            return isValid;
        }

        internal Board(int i_Row, int i_Column)
        {
            r_NumberOfRow = i_Row;
            r_NumberOfColumn = i_Column;
            r_GameBoard = new char[i_Row, i_Column];
            ////intilaize to empty board
            for (int columnIndex = 0; columnIndex < numberOfColumn; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < numberOfRow; rowIndex++)
                {
                    gameBoard[rowIndex, columnIndex] = (char)Player.ePlayerSign.Empty;
                }
            }
        }

        internal int numberOfColumn
        {
            get
            {
                return r_NumberOfColumn;
            }
        }

        internal int numberOfRow
        {
            get
            {
                return r_NumberOfRow;
            }
        }

        internal char[,] gameBoard
        {
            get
            {
                return r_GameBoard;
            }
        }

        internal void ClearBoard()
        {
            for (int columnIndex = 0; columnIndex < numberOfColumn; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < numberOfRow; rowIndex++)
                {
                    gameBoard[rowIndex, columnIndex] = (char)Player.ePlayerSign.Empty;
                }
            }
        }

        internal void Delete(int i_RowIndex, int i_ColumnIndex)
        {
            gameBoard[i_RowIndex, i_ColumnIndex] = (char)Player.ePlayerSign.Empty;
        }
    }
}
