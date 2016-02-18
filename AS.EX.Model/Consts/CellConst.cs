namespace AS.EX.Model.Consts
{
    /// <summary>
    /// Cell constants.
    /// </summary>
    public class CellConst
    {
        /// <summary>
        /// The expression symbol
        /// </summary>
        public const string ExpressionSymbol = "=";

        /// <summary>
        /// The text symbol
        /// </summary>
        public const string TextSymbol = "'";

        /// <summary>
        /// The zero index
        /// </summary>
        public const int ZeroIndex = 0;

        /// <summary>
        /// All numbers
        /// </summary>
        public static readonly char[] AllNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        /// <summary>
        /// The operation symbols
        /// </summary>
        public static readonly char[] OperationSymbols = { '+', '-', '*', '/' };
    }
}