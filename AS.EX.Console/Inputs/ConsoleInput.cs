﻿using AS.EX.Console.Inputs.Interfaces;
using AS.EX.Model.Excel.Data.Cells;
using AS.EX.Model.Excel.Data.Cells.Properties;
using AS.EX.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace AS.EX.Console.Inputs
{
    /// <summary>
    /// Console input class
    /// </summary>
    /// <seealso cref="AS.EX.Console.Inputs.Interfaces.IInput" />
    public class ConsoleInput : IInput
    {
        private const int TableVariableCount = 2;
        private int _columnCount;

        private bool _isConfigure;
        private int _rowCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleInput" /> class.
        /// </summary>
        public ConsoleInput()
        {
            Cells = new List<ICell>();
        }

        /// <summary>
        /// Gets or sets the cells.
        /// </summary>
        /// <value>
        /// The cells.
        /// </value>
        public List<ICell> Cells { get; set; }

        /// <summary>
        /// Gets or sets the column count.
        /// </summary>
        /// <value>
        /// The column count.
        /// </value>
        public int ColumnCount { get; set; }

        /// <summary>
        /// Gets or sets the row count.
        /// </summary>
        /// <value>
        /// The row count.
        /// </value>
        public int RowCount { get; set; }

        /// <summary>
        /// Starts the console input.
        /// </summary>
        public void StartInput()
        {
            do
            {
                StartConfigure();
            } while (!_isConfigure);
        }

        private static string[] GetValueFromConsoleByTab()
        {
            var consoleValue = System.Console.ReadLine();
            var strings = consoleValue?.Split('\t');

            return strings;
        }

        private static void ThrowIfIncorrectInputSize(string[] array, int countInRow)
        {
            if (array.Length != countInRow)
            {
                throw new ArgumentException($@"Incorrect input value size. Should be {countInRow} values in row");
            }
        }

        private void SetTableCells()
        {
            System.Console.WriteLine(@"Enter cell values");
            for (var rowIndex = 0; rowIndex < RowCount; rowIndex++)
            {
                var values = GetValueFromConsoleByTab();
                ThrowIfIncorrectInputSize(values, ColumnCount);

                for (var columnIndex = 0; columnIndex < values.Length; columnIndex++)
                {
                    ICellProperties cellProperties = new CellProperties(values[columnIndex]);
                    cellProperties.SetupProperties();

                    ICell cell = new Cell(columnIndex, rowIndex, cellProperties);
                    cell.SetupProperties();

                    Cells.Add(cell);
                }
            }
        }

        private void SetTableSize()
        {
            System.Console.WriteLine(@"Enter table size: row, count");

            var values = GetValueFromConsoleByTab();
            ThrowIfIncorrectInputSize(values, TableVariableCount);

            int.TryParse(values[0], out _rowCount);
            RowCount = _rowCount;

            int.TryParse(values[1], out _columnCount);
            ColumnCount = _columnCount;

            ThrowIfIntegerLessOrEqualZero(RowCount, nameof(RowCount));
            ThrowIfIntegerLessOrEqualZero(ColumnCount, nameof(ColumnCount));

            System.Console.WriteLine($@"Table size is: Row = {RowCount}, Count = {ColumnCount}");
        }

        private void StartConfigure()
        {
            try
            {
                SetTableSize();
                SetTableCells();
                _isConfigure = true;
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"\nException: {e.Message}. Try again.");
                _isConfigure = false;
            }
        }

        private void ThrowIfIntegerLessOrEqualZero(int number, string parameter)
        {
            if (number <= 0)
            {
                throw new ArgumentException($@"{number} less than 0 in parameter {parameter}");
            }
        }
    }
}