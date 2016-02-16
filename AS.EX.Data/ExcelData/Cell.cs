using System;
using System.Linq;
using AS.EX.Data.Consts;
using AS.EX.Data.ExcelData.Analyzers;
using AS.EX.Data.ExcelData.Converters;
using AS.EX.Data.ExcelData.EnumTypes;

namespace AS.EX.Data.ExcelData
{
    public class Cell
    {

        public int ColumnIndex { get; set; }
        public int RowIndex { get; set; }

        public CellTypeEnum CellType { get; set; }
        public string CellValue { get; set; }

        public bool IsCalculated { get; set; }

        public string ColumnName { get; private set; }


        public Cell(int column, int row, CellProperties properties)
        {
            ColumnIndex = column;
            RowIndex = row;
            CellType = properties.CellType;
            CellValue = properties.CellValue;
            IsCalculated = properties.IsCalculated;

            SetupProperties();
        }


        private void SetupProperties()
        {
            SetupColumnName();
        }

        private void SetupColumnName()
        {
            ColumnName = Converter.CellNumberToColumnName(ColumnIndex);
        }

        public string GetCellCoordinate()
        {
            int rowNumber = RowIndex + TableCellConst.StartRowIndex;
            return ColumnName + rowNumber;
        }


        private static void ErrorCellIfNegativeNumber(Cell cell)
        {
            var value = Convert.ToInt32(cell.CellValue);
            if (value < 0)
            {
                cell.SetCellErrorState("Negative number");
            }
        }

        public bool ErrorCellIfCellHasReferenceToItself()
        {
            var isReferenceToItSelfPresent = false;

            if (CellValue != null)
            {
                string[] values = CellValue.Split(OperationAnalyzer.GetOperationSymbols());

                if (values.ToArray().Contains(GetCellCoordinate()))
                {
                    isReferenceToItSelfPresent = true;
                    CellType = CellTypeEnum.Error;
                }
            }

            return isReferenceToItSelfPresent;
        }

        public void SetCellErrorState(string errorMessage)
        {
            const string errorFirstSymbol = "#";

            CellType = CellTypeEnum.Error;
            CellValue = errorFirstSymbol + errorMessage;
        }


        public override string ToString()
        {
            return $"Cell: {GetCellCoordinate()}, CellType: {CellType}, IsCalculated: {IsCalculated}, CellValue: {CellValue}";
        }
    }
}