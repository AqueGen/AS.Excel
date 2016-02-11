using System.Linq;
using AS.EX.Converters.Converters;
using AS.EX.Data.ExcelData.Types;

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
        public string CellCoordinate
        {
            get
            {
                var rowNumber = RowIndex + FirstRowInExcel;
                return ColumnName + rowNumber;
            }
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
            get { return Converter.Number2ColumnName(ColumnIndex); }
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
            IsCalculated = !CellAnalyze.IsCellReferencePresent(Value) && !CellAnalyze.IsArithmeticOperationPresent(value);
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
                var values = Value.Split(EnumHelper.ArithmeticTypeEnumHelper.GetOperationSymbols());

                if (values.Contains(CellCoordinate))
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


        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return
                $"CellReference: {CellCoordinate}, ColumnIndex: {ColumnIndex}, ColumnName: {ColumnName}, IsCalculated: {IsCalculated}, RowIndex: {RowIndex}, Type: {Type}, Value: {Value}.";
        }
    }
}