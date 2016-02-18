using System.Collections.Generic;

namespace AS.EX.Model.Interfaces
{
    /// <summary>
    /// Table interface.
    /// </summary>
    public interface ITable
    {
        /// <summary>
        /// Gets the cells.
        /// </summary>
        /// <value>
        /// The cells.
        /// </value>
        List<ICell> Cells { get; }

        /// <summary>
        /// Adds the cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        void AddCell(ICell cell);

        /// <summary>
        /// Calculates the cells.
        /// </summary>
        void CalculateCells();

        /// <summary>
        /// Gets the cell.
        /// </summary>
        /// <param name="cellReference">The cell reference.</param>
        /// <returns></returns>
        ICell GetCell(string cellReference);
    }
}