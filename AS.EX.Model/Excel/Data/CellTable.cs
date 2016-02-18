using AS.EX.Model.Excel.Analyzers;
using AS.EX.Model.Excel.Calculates;
using AS.EX.Model.Excel.Converters;
using AS.EX.Model.Excel.EnumTypes;
using AS.EX.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace AS.EX.Model.Excel.Data
{
    /// <summary>
    /// Cell table class
    /// </summary>
    /// <seealso cref="AS.EX.Model.Interfaces.ITable" />
    public class CellTable : ITable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CellTable"/> class.
        /// </summary>
        public CellTable()
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
        /// Adds the cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void AddCell(ICell cell)
        {
            if (cell == null) throw new ArgumentNullException(nameof(cell));

            Cells.Add(cell);
        }

        /// <summary>
        /// Calculates the cells.
        /// </summary>
        public void CalculateCells()
        {
            bool isChangedCellValue;
            do
            {
                isChangedCellValue = false;
                foreach (var cell in Cells)
                {
                    CalculateCell(ref isChangedCellValue, cell);
                }
            } while (isChangedCellValue);
        }

        /// <summary>
        /// Gets the cell.
        /// </summary>
        /// <param name="cellReference">The cell reference.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">
        /// Argument is null or whitespace
        /// or
        /// Cell not found
        /// </exception>
        public ICell GetCell(string cellReference)
        {
            if (string.IsNullOrWhiteSpace(cellReference))
                throw new ArgumentException("Argument is null or whitespace", nameof(cellReference));

            foreach (var cell in Cells)
            {
                if (cell.GetCellCoordinate().Equals(cellReference))
                {
                    return cell;
                }
            }
            throw new ArgumentException("Cell not found");
        }

        private static void CalculateNumbers(ICell cell)
        {
            if (cell == null) throw new ArgumentNullException(nameof(cell));

            if (!ReferenceCellAnalyzer.IsCellReferencePresent(cell.Value) && cell.Type != CellTypeEnum.Error)
            {
                cell.Type = CellTypeEnum.Number;
                cell.Value = CellExpression.Calculate(cell);
                cell.IsCalculated = true;
            }
        }

        private static bool IsChangedValue(string currentValue, string previousValue)
        {
            if (string.IsNullOrWhiteSpace(currentValue))
                throw new ArgumentException("Argument is null or whitespace", nameof(currentValue));
            if (string.IsNullOrWhiteSpace(previousValue))
                throw new ArgumentException("Argument is null or whitespace", nameof(previousValue));

            return !currentValue.Equals(previousValue);
        }

        private void CalculateCell(ref bool isChangedCellValue, ICell cell)
        {
            if (cell == null) throw new ArgumentNullException(nameof(cell));

            if (!cell.IsCalculated && cell.Type != CellTypeEnum.Error)
            {
                string oldCellValue = cell.Value;

                try
                {
                    Converter.ConvertCellReferenceToValue(this, cell);
                    cell.CheckReferenceToItSelf();

                    CalculateNumbers(cell);
                }
                catch (Exception e)
                {
                    cell.SetErrorValue(e.Message);
                }

                if (!isChangedCellValue)
                {
                    isChangedCellValue = IsChangedValue(cell.Value, oldCellValue);
                }
            }
        }
    }
}