using AS.EX.Console.Outputs.Interfaces;
using AS.EX.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace AS.EX.Console.Outputs
{
    /// <summary>
    /// Console output class.
    /// </summary>
    /// <seealso cref="AS.EX.Console.Outputs.Interfaces.IOutput" />
    public class ConsoleOutput : IOutput
    {
        private readonly List<ICell> _cells;
        private readonly int _column;
        private readonly int _row;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOutput"/> class.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        /// <param name="cells">The cells.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// </exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public ConsoleOutput(int row, int column, List<ICell> cells)
        {
            if (row <= 0) throw new ArgumentOutOfRangeException(nameof(row));
            if (column <= 0) throw new ArgumentOutOfRangeException(nameof(column));
            if (cells == null) throw new ArgumentNullException(nameof(cells));

            _row = row;
            _column = column;
            _cells = cells;
        }

        /// <summary>
        /// Starts the output.
        /// </summary>
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