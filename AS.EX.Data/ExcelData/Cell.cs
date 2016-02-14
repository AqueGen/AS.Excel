using System.Linq;
using AS.EX.Data.ExcelData.Analyzers;
using AS.EX.Data.ExcelData.Converters;
using AS.EX.Data.ExcelData.EnumTypes;

namespace AS.EX.Data.ExcelData
{
    public class Cell
    {
        private const int FirstRowInExcel = 1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Cell" /> class.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="row">The row.</param>
        public Cell(int column, int row)
        {
            ColumnIndex = column;
            RowIndex = row;
        }

        /// <summary>
        ///     Gets the cell coordinate.
        /// </summary>
        /// <value>
        ///     The cell coordinate.
        /// </value>
        public string GetCellCoordinate()
        {
            var rowNumber = RowIndex + FirstRowInExcel;
            return ColumnName + rowNumber;
        }

        /// <summary>
        ///     Gets or sets the index of the column.
        /// </summary>
        /// <value>
        ///     The index of the column.
        /// </value>
        public int ColumnIndex { get; set; }

        /// <summary>
        ///     Gets the name of the column.
        /// </summary>
        /// <value>
        ///     The name of the column.
        /// </value>
        public string ColumnName
        {
            get { return Converter.CellNumberToColumnName(ColumnIndex); }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is calculated.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is calculated; otherwise, <c>false</c>.
        /// </value>
        public bool IsCalculated { get; set; }

        /// <summary>
        ///     Gets or sets the index of the row.
        /// </summary>
        /// <value>
        ///     The index of the row.
        /// </value>
        public int RowIndex { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public CellType Type { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public string Value { get; set; }


        /// <summary>
        ///     Sets the variables.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <param name="isCalculated">if set to <c>true</c> [is calculated].</param>
        public void SetVariables(string value, CellType type, bool isCalculated)
        {
            Value = value;
            Type = type;
            IsCalculated = !ExcelCellAnalyzer.IsCellReferencePresent(Value) && !ExcelCellAnalyzer.IsArithmeticOperationPresent(value);
        }

        /// <summary>
        ///     Determines whether [is cell has reference to itself].
        /// </summary>
        /// <returns></returns>
        public bool IsCellHasReferenceToItself()
        {
            var isReferenceToItSelfPresent = false;

            if (Value != null)
            {
                var values = Value.Split(OperationAnalyzer.GetOperationSymbols());

                if (values.Contains(GetCellCoordinate()))
                {
                    isReferenceToItSelfPresent = true;
                    Type = CellType.Error;
                }
            }

            return isReferenceToItSelfPresent;
        }

        /// <summary>
        ///     Sets the state of the cell error.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public void SetCellErrorState(string errorMessage)
        {
            const string errorFirstSymbol = "#";

            IsCalculated = true;
            Type = CellType.Error;
            Value = errorFirstSymbol + errorMessage;
        }

        #region Overload binnary operations
        public static Cell operator +(Cell obj1, Cell obj2)
        {
            return new Cell(1, 1);
        }

        public static Cell operator -(Cell obj1, Cell obj2)
        {
            return new Cell(1, 1);
        }

        public static Cell operator /(Cell obj1, Cell obj2)
        {
            return new Cell(1, 1);
        }

        public static Cell operator *(Cell obj1, Cell obj2)
        {
            return new Cell(1, 1);
        }
        #endregion Overload binnary operations


        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return
                $"CellReference: {GetCellCoordinate()}, ColumnIndex: {ColumnIndex}, ColumnName: {ColumnName}, IsCalculated: {IsCalculated}, RowIndex: {RowIndex}, Type: {Type}, Value: {Value}.";
        }
    }
}