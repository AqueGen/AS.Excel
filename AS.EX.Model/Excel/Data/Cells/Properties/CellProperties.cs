using System;
using AS.EX.Model.Excel.Analyzers.CellProperties;
using AS.EX.Model.Excel.EnumTypes;
using AS.EX.Model.Interfaces;

namespace AS.EX.Model.Excel.Data.Cells.Properties
{
    public class CellProperties : ICellProperties
    {
        private readonly string _value;

        public CellTypeEnum Type {get; set; }
        public string Value { get; set; }
        public bool IsCalculated { get; set; }

        public CellProperties(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            _value = value;
        }

        public void SetupProperties()
        {
            SetupCellType();
            SetupValue();
            SetupIsCalculated();
        }


        private void SetupCellType()
        {
            Type = CellTypeAnalyzer.GetCellType(_value);
        }
        private void SetupValue()
        {
            Value = CellValueAnalyzer.GetCellValue(Type, _value);
        }

        private void SetupIsCalculated()
        {
            IsCalculated = CellIsCalculatedAnalyzer.IsCalculated(Type);
        }

    }
}