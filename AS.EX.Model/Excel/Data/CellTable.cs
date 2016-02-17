using System;
using System.Collections.Generic;
using AS.EX.Model.Excel.Analyzers;
using AS.EX.Model.Excel.Calculates;
using AS.EX.Model.Excel.Converters;
using AS.EX.Model.Excel.EnumTypes;
using AS.EX.Model.Interfaces;

namespace AS.EX.Model.Excel.Data
{
    public class CellTable : ITable
    {

        public CellTable()
        {
            Cells = new List<ICell>();
        }

        public List<ICell> Cells { get; set; }

        public void AddCell(ICell cell)
        {
            Cells.Add(cell);
        }


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

        private void CalculateCell(ref bool isChangedCellValue, ICell cell)
        {
            if (cell == null) throw new ArgumentNullException(nameof(cell));

            if (!cell.IsCalculated && cell.Type != CellTypeEnum.Error)
            {
                string oldCellValue = cell.Value;

                cell.Value = Converter.ConvertCellReferenceToValue(this, cell);

                if (!ReferenceCellAnalyzer.IsCellReferencePresent(cell.Value))
                {
                    CalculateNumbers(cell);
                }

                ThrowIfCellHasReferenceToItSelf(cell);

                if(!isChangedCellValue)
                {
                    isChangedCellValue = IsChangedValue(cell.Value, oldCellValue);
                }
            }
        }

        private static void ThrowIfCellHasReferenceToItSelf(ICell cell)
        {
            if (cell == null) throw new ArgumentNullException(nameof(cell));

            if (cell.IsHasReferenceToItself())
            {
                cell.SetErrorValue("Reference To Self Cell");
            }
        }

        private static void CalculateNumbers(ICell cell)
        {
            if (cell == null) throw new ArgumentNullException(nameof(cell));

            cell.Type = CellTypeEnum.Number;
            cell.Value = CellExpression.Calculate(cell);
            cell.IsCalculated = true;
        }

        public ICell GetCell(string cellReference)
        {
            if (String.IsNullOrWhiteSpace(cellReference))
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


        private static bool IsChangedValue(string currentValue, string previousValue)
        {
            if (String.IsNullOrWhiteSpace(currentValue))
                throw new ArgumentException("Argument is null or whitespace", nameof(currentValue));
            if (String.IsNullOrWhiteSpace(previousValue))
                throw new ArgumentException("Argument is null or whitespace", nameof(previousValue));

            return !currentValue.Equals(previousValue);
        }
    }
}