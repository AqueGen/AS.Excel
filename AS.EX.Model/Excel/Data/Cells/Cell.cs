using AS.EX.Model.Consts;
using AS.EX.Model.Excel.Converters;
using AS.EX.Model.Excel.EnumTypes;
using AS.EX.Model.Interfaces;
using System;
using System.Linq;

namespace AS.EX.Model.Excel.Data.Cells
{
    /// <summary>
    /// Cell class
    /// </summary>
    /// <seealso cref="AS.EX.Model.Interfaces.ICell" />
    public class Cell : ICell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        /// <param name="properties">The properties.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public Cell(int column, int row, ICellProperties properties)
        {
            if (properties == null) throw new ArgumentNullException(nameof(properties));

            ColumnIndex = column;
            RowIndex = row;
            Type = properties.Type;
            Value = properties.Value;
            IsCalculated = properties.IsCalculated;
        }

        /// <summary>
        /// Gets or sets the index of the column.
        /// </summary>
        /// <value>
        /// The index of the column.
        /// </value>
        public int ColumnIndex { get; set; }

        /// <summary>
        /// Gets the name of the column.
        /// </summary>
        /// <value>
        /// The name of the column.
        /// </value>
        public string ColumnName { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is calculated.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is calculated; otherwise, <c>false</c>.
        /// </value>
        public bool IsCalculated { get; set; }

        /// <summary>
        /// Gets or sets the index of the row.
        /// </summary>
        /// <value>
        /// The index of the row.
        /// </value>
        public int RowIndex { get; set; }

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
        /// Checks the reference to it self.
        /// </summary>
        /// <exception cref="System.ApplicationException">Reference to itself</exception>
        public void CheckReferenceToItSelf()
        {
            if (IsHasReferenceToItself())
            {
                throw new ApplicationException("Reference to itself");
            }
        }

        /// <summary>
        /// Gets the cell coordinate.
        /// </summary>
        /// <returns></returns>
        public string GetCellCoordinate()
        {
            int rowNumber = RowIndex + TableCellConst.StartRowIndex;
            return ColumnName + rowNumber;
        }

        /// <summary>
        /// Determines whether [is has reference to itself].
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Sets the error value.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <exception cref="System.ArgumentException">Argument is null or whitespace</exception>
        public void SetErrorValue(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentException("Argument is null or whitespace", nameof(errorMessage));

            const string errorFirstSymbol = "#";

            Type = CellTypeEnum.Error;
            Value = errorFirstSymbol + errorMessage;
        }

        /// <summary>
        /// Setups the properties.
        /// </summary>
        public void SetupProperties()
        {
            ColumnName = Converter.CellNumberToColumnName(ColumnIndex);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Cell: {GetCellCoordinate()}, CellType: {Type}, IsCalculated: {IsCalculated}, CellValue: {Value}";
        }
    }
}