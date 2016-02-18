using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Interfaces
{
    /// <summary>
    /// Cell properties interface.
    /// </summary>
    /// <seealso cref="AS.EX.Model.Interfaces.IProperties" />
    public interface ICellProperties : IProperties
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is calculated.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is calculated; otherwise, <c>false</c>.
        /// </value>
        bool IsCalculated { get; set; }

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
    }
}