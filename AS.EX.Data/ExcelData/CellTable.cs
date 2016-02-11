using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AS.EX.Data.ExcelData.Types;

namespace AS.EX.Data.ExcelData
{
    public class CellTable
    {
        private readonly int _columnLength;
        private readonly int _rowLength;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CellTable" /> class.
        /// </summary>
        /// <param name="columns">The columns.</param>
        /// <param name="rows">The rows.</param>
        public CellTable(int columns, int rows)
        {
            Cells = new List<Cell>();
            _columnLength = columns;
            _rowLength = rows;
        }

        /// <summary>
        ///     Gets or sets the cells.
        /// </summary>
        /// <value>
        ///     The cells.
        /// </value>
        public List<Cell> Cells { get; set; }

        /// <summary>
        ///     Adds the cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        public void AddCell(Cell cell)
        {
            Cells.Add(cell);
            Console.WriteLine($@"Added new Cell: {cell}");
        }


        /// <summary>
        ///     Casts the reference field to value.
        /// </summary>
        public void CalculateCells()
        {
            bool isChangedCellValue;
            do
            {
                isChangedCellValue = false;
                foreach (var cell in Cells)
                {
                    CalculateIfNotCalculated(ref isChangedCellValue, cell);
                }
            } while (isChangedCellValue);
        }

        private void CalculateIfNotCalculated(ref bool isChangedCellValue, Cell cell)
        {
            if (!cell.IsCalculated && cell.Type != CellType.Error)
            {
                CalculateCellValue(ref isChangedCellValue, cell);
            }
        }

        private void CalculateCellValue(ref bool isChangedCellValue, Cell cell)
        {
            try
            {
                var oldCellValue = cell.Value;
                ConvertReferenceToReferenceValue(cell);

                CalculateIfCellReferenceAbsent(cell);

                if (cell.IsCellHasReferenceToItself())
                {
                    cell.SetCellErrorState(ErrorMessage.ReferenceToSelfCell);
                }

                if (!isChangedCellValue)
                {
                    isChangedCellValue = IsChangedValue(cell.Value, oldCellValue);
                }
            }
            catch (Exception e)
            {
                cell.SetCellErrorState(e.Message);
            }
        }

        private void ConvertReferenceToReferenceValue(Cell cell)
        {
            cell.Value = Expression.CastReferenceToValue(this, cell);
        }

        private static void CalculateIfCellReferenceAbsent(Cell cell)
        {
            if (!CellAnalyze.IsCellReferencePresent(cell.Value))
            {
                cell.Type = CellType.Number;
                cell.Value = Expression.CalculateExpression(cell);
                cell.IsCalculated = true;
            }
        }

        /// <summary>
        ///     Get the cell by cell reference.
        /// </summary>
        /// <param name="cellReference">The cell reference.</param>
        /// <returns></returns>
        public Cell GetCell(string cellReference)
        {
            foreach (var cell in Cells)
            {
                if (cell.CellCoordinate == cellReference)
                {
                    return cell;
                }
            }
            throw new ArgumentException("Cell not found");
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"ColumnLength: {_columnLength}, RowLength: {_rowLength}, Cells: {Cells.Count}.";
        }


        private static bool IsChangedValue(string currentValue, string previousValue)
        {
            return currentValue != previousValue;
        }
    }
}