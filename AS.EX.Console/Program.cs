using AS.EX.Console.Inputs;
using AS.EX.Console.Inputs.Interfaces;
using AS.EX.Data.ExcelData;

namespace AS.EX.Console
{
    class Program
    {
        static void Main()
        {
            System.Console.WriteLine(@"Start Excel Program");

            IInput input = new ConsoleInput();
            input.StartInput();

            CellTable table = new CellTable(input.RowCount, input.ColumnCount);

            foreach (Cell cell in input.Cells)
            {
                table.AddCell(cell);
            }
        }
    }
}
