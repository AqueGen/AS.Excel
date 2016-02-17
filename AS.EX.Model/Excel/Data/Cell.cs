using System;
using System.Linq;
using AS.EX.Model.Consts;
using AS.EX.Model.Excel.Analyzers;
using AS.EX.Model.Excel.Converters;
using AS.EX.Model.Excel.Data.Properties;
using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Excel.Data
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

        public bool IsHasReferenceToItself()
        {
            bool isReferenceToItSelfPresent = false;

            if (CellValue != null)
            {
                string[] values = CellValue.Split(OperationAnalyzer.GetOperationSymbols());

                if (values.ToArray().Contains(GetCellCoordinate()))
                {
                    isReferenceToItSelfPresent = true;
                }
            }

            return isReferenceToItSelfPresent;
        }

        public void SetErrorValue(string errorMessage)
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