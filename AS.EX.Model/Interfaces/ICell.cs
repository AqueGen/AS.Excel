using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Interfaces
{
    /// <summary>
    /// Cell interface
    /// </summary>
    /// <seealso cref="AS.EX.Model.Interfaces.IProperties" />
    public interface ICell : IProperties
    {
        /// <summary>
        /// Gets or sets the index of the column.
        /// </summary>
        /// <value>
        /// The index of the column.
        /// </value>
        int ColumnIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is calculated.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is calculated; otherwise, <c>false</c>.
        /// </value>
        bool IsCalculated { get; set; }

        /// <summary>
        /// Gets or sets the index of the row.
        /// </summary>
        /// <value>
        /// The index of the row.
        /// </value>
        int RowIndex { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        CellTypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        string Value { get; set; }

        /// <summary>
        /// Checks the reference to it self.
        /// </summary>
        void CheckReferenceToItSelf();

        /// <summary>
        /// Gets the cell coordinate.
        /// </summary>
        /// <returns></returns>
        string GetCellCoordinate();

        /// <summary>
        /// Determines whether [is has reference to itself].
        /// </summary>
        /// <returns></returns>
        bool IsHasReferenceToItself();

        /// <summary>
        /// Sets the error value.
        /// </summary>
        /// <param name="message">The message.</param>
        void SetErrorValue(string message);
    }
}