﻿using System;
using AS.EX.Model.Consts;
using AS.EX.Model.Excel.Analyzers;
using AS.EX.Model.Excel.Data;
using AS.EX.Model.Excel.Data.Cells;
using AS.EX.Model.Excel.EnumTypes;
using AS.EX.Model.Interfaces;

namespace AS.EX.Model.Excel.Converters
{
    public class CellValueConverter
    {
        public static void ConvertCellReferenceToValue(ITable table, ICell cell)
        {
            if (table == null) throw new ArgumentNullException(nameof(table));
            if (cell == null) throw new ArgumentNullException(nameof(cell));

            string[] parts = cell.Value.Split(CellConst.OperationSymbols);

            CheckExpressionParts(cell, parts);

            foreach (string part in parts)
            {
                if(cell.Type != CellTypeEnum.Error && ReferenceCellAnalyzer.IsCellReferencePresent(part))
                {
                    ReplaceReferenceToValue(table, cell, part);
                }
            }
        }


        private static void ReplaceReferenceToValue(ITable table, ICell cell, string part)
        {
            ICell foundCell = table.GetCell(part);

            if (foundCell?.Type == CellTypeEnum.Error)
            {
                cell.SetErrorValue("Reference cell with error");
            }

            if (foundCell?.Value != null && foundCell.IsCalculated)
            {
                cell.Value = cell.Value.Replace(part, foundCell.Value);
            }
        }


        private static void CheckExpressionParts(ICell cell, string[] parts)
        {
            string firstSymbol = cell.Value.Substring(0, 1);
            if (firstSymbol.Equals("*") || firstSymbol.Equals("/"))
            {
                cell.SetErrorValue("First symbol can not be multiple or divide");
            }
        }

    }
}