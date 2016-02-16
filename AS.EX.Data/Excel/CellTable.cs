using System;
using System.Collections.Generic;
using AS.EX.Model.Excel.Analyzers;
using AS.EX.Model.Excel.Calculates;
using AS.EX.Model.Excel.Converters;
using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Excel
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
                    CalculateIfNotCalculated(ref isChangedCellValue, cell);
                }
            } while (isChangedCellValue);
        }

        private void CalculateIfNotCalculated(ref bool isChangedCellValue, Cell cell)
        {
            if (!cell.IsCalculated && cell.CellType != CellTypeEnum.Error)
            {
                CalculateCellValue(ref isChangedCellValue, cell);
            }
        }

        private void CalculateCellValue(ref bool isChangedCellValue, Cell cell)
        {
            string oldCellValue = cell.CellValue;

            ConvertCellReferenceToValue(this, cell);

            CalculateIfCellReferenceAbsent(cell);

            ThrowIfCellHasReferenceToItSelf(cell);

            if(!isChangedCellValue)
            {
                isChangedCellValue = CheckIsChangedCellValue(cell.CellValue, oldCellValue);
            }
        }

        private static bool CheckIsChangedCellValue(string cellValue, string oldCellValue)
        {
            bool isChangedCellValue = IsChangedValue(cellValue, oldCellValue);
            return isChangedCellValue;
        }

        private static void ThrowIfCellHasReferenceToItSelf(Cell cell)
        {
            if (cell.ErrorCellIfCellHasReferenceToItself())
            {
                cell.SetCellErrorState("ReferenceToSelfCell");
            }
        }

        private void ConvertCellReferenceToValue(CellTable table, Cell cell)
        {
            cell.CellValue = Converter.ConvertCellReferenceToValue(table, cell);
        }

        private static void CalculateIfCellReferenceAbsent(Cell cell)
        {
            if (!ExcelCellAnalyzer.IsCellReferencePresent(cell.CellValue))
            {
                cell.CellType = CellTypeEnum.Number;
                cell.CellValue = CellExpression.Calculate(cell);
                cell.IsCalculated = true;
            }
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