using AS.EX.Model.Interfaces;
using System.Collections.Generic;

namespace AS.EX.Console.Inputs.Interfaces
{
    /// <summary>
    /// Input interface.
    /// </summary>
    public interface IInput
    {
        /// <summary>
        /// Gets the cells.
        /// </summary>
        /// <value>
        /// The cells.
        /// </value>
        List<ICell> Cells { get; set; }

        /// <summary>
        /// Gets or sets the column count.
        /// </summary>
        /// <value>
        /// The column count.
        /// </value>
        int ColumnCount { get; set; }

        /// <summary>
        /// Gets or sets the row count.
        /// </summary>
        /// <value>
        /// The row count.
        /// </value>
        int RowCount { get; set; }

        /// <summary>
        /// Starts the input.
        /// </summary>
        void StartInput();
    }
}