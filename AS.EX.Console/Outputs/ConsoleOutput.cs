using System;
using System.Collections.Generic;
using AS.EX.Console.Outputs.Interfaces;
using AS.EX.Model.Interfaces;

namespace AS.EX.Console.Outputs
{
    public class ConsoleOutput : IOutput
    {
        private readonly int _row;
        private readonly int _column;
        private readonly List<ICell> _cells;

        public ConsoleOutput(int row, int column, List<ICell> cells)
        {
            if (row <= 0) throw new ArgumentOutOfRangeException(nameof(row));
            if (column <= 0) throw new ArgumentOutOfRangeException(nameof(column));
            if (cells == null) throw new ArgumentNullException(nameof(cells));


            _row = row;
            _column = column;
            _cells = cells;
        }


        public void StartOutput()
        {
            int cellIndex = 0;

            for (int r = 0; r < _row; r++)
            {
                string rowOutputValue = string.Empty;
                for (int c = 0; c < _column; c++)
                {
                    if (cellIndex < _cells.Count)
                    {
                        rowOutputValue += _cells[cellIndex].Value + "\t";
                        cellIndex++;
                    }
                }
                rowOutputValue = rowOutputValue.TrimEnd('\t');
                System.Console.WriteLine(rowOutputValue);
            }
        }
    }
}