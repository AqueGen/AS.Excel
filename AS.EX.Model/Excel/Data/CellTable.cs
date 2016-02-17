using System;
using System.Collections.Generic;
using AS.EX.Model.Excel.Analyzers;
using AS.EX.Model.Excel.Calculates;
using AS.EX.Model.Excel.Converters;
using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Excel.Data
{
    public class CellTable
    {

        public CellTable()
        {
            Cells = new List<Cell>();
        }

        public List<Cell> Cells { get; set; }

        public void AddCell(Cell cell)
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

        private void CalculateCell(ref bool isChangedCellValue, Cell cell)
        {
            if (!cell.IsCalculated && cell.CellType != CellTypeEnum.Error)
            {
                string oldCellValue = cell.CellValue;

                cell.CellValue = Converter.ConvertCellReferenceToValue(this, cell);

                if (!ExcelCellAnalyzer.IsCellReferencePresent(cell.CellValue))
                {
                    CalculateNumbers(cell);
                }

                ThrowIfCellHasReferenceToItSelf(cell);

                if(!isChangedCellValue)
                {
                    isChangedCellValue = IsChangedValue(cell.CellValue, oldCellValue);
                }
            }
        }

        private static void ThrowIfCellHasReferenceToItSelf(Cell cell)
        {
            if (cell.IsHasReferenceToItself())
            {
                cell.SetErrorValue("ReferenceToSelfCell");
            }
        }

        private static void CalculateNumbers(Cell cell)
        {
            cell.CellType = CellTypeEnum.Number;
            cell.CellValue = CellExpression.Calculate(cell);
            cell.IsCalculated = true;
        }

        public Cell GetCell(string cellReference)
        {
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
            return !currentValue.Equals(previousValue);
        }
    }
}