﻿using AS.EX.Model.Consts;
using AS.EX.Model.Excel.Converters;
using AS.EX.Model.Excel.EnumTypes;
using AS.EX.Model.Interfaces;
using System;
using System.Linq;

namespace AS.EX.Model.Excel.Data.Cells
{
    public class Cell : ICell
    {
        public Cell(int column, int row, ICellProperties properties)
        {
            if (properties == null) throw new ArgumentNullException(nameof(properties));

            ColumnIndex = column;
            RowIndex = row;
            Type = properties.Type;
            Value = properties.Value;
            IsCalculated = properties.IsCalculated;
        }

        public int ColumnIndex { get; set; }
        public string ColumnName { get; private set; }
        public bool IsCalculated { get; set; }
        public int RowIndex { get; set; }

        public CellTypeEnum Type { get; set; }

        public string Value { get; set; }

        public void CheckReferenceToItSelf()
        {
            if (IsHasReferenceToItself())
            {
                throw new ApplicationException("Reference to itself");
            }
        }

        public string GetCellCoordinate()
        {
            int rowNumber = RowIndex + TableCellConst.StartRowIndex;
            return ColumnName + rowNumber;
        }

        public bool IsHasReferenceToItself()
        {
            bool isReferenceToItSelfPresent = false;

            if (Value != null)
            {
                string[] values = Value.Split(CellConst.OperationSymbols);

                if (values.ToArray().Contains(GetCellCoordinate()))
                {
                    isReferenceToItSelfPresent = true;
                }
            }

            return isReferenceToItSelfPresent;
        }

        public void SetErrorValue(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentException("Argument is null or whitespace", nameof(errorMessage));

            const string errorFirstSymbol = "#";

            Type = CellTypeEnum.Error;
            Value = errorFirstSymbol + errorMessage;
        }

        public void SetupProperties()
        {
            ColumnName = Converter.CellNumberToColumnName(ColumnIndex);
        }

        public override string ToString()
        {
            return $"Cell: {GetCellCoordinate()}, CellType: {Type}, IsCalculated: {IsCalculated}, CellValue: {Value}";
        }
    }
}