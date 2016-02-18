using AS.EX.Model.Excel.Analyzers.CellProperties;
using AS.EX.Model.Excel.EnumTypes;
using AS.EX.Model.Interfaces;
using System;

namespace AS.EX.Model.Excel.Data.Cells.Properties
{
    /// <summary>
    /// Cell properties class
    /// </summary>
    /// <seealso cref="AS.EX.Model.Interfaces.ICellProperties" />
    public class CellProperties : ICellProperties
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CellProperties" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public CellProperties(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            _value = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is calculated.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is calculated; otherwise, <c>false</c>.
        /// </value>
        public bool IsCalculated { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public CellTypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Setups the properties.
        /// </summary>
        public void SetupProperties()
        {
            Type = CellTypeAnalyzer.GetCellType(_value);
            Value = CellValueAnalyzer.GetCellValue(Type, _value);
            IsCalculated = CellIsCalculatedAnalyzer.IsCalculated(Type);
        }
    }
}