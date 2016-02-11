namespace AS.EX.Data.ExcelData.Types
{
    public enum OperationType
    {
        /// <summary>
        ///     Non setup operation.
        /// </summary>
        Default,

        /// <summary>
        ///     The add math operation.
        /// </summary>
        Add = '+',

        /// <summary>
        ///     The subtract math operation.
        /// </summary>
        Subtract = '-',

        /// <summary>
        ///     The multiply math operation.
        /// </summary>
        Multiply = '*',

        /// <summary>
        ///     The divide math operation.
        /// </summary>
        Divide = '/'
    }
}