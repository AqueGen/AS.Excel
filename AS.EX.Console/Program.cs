using AS.EX.Console.Inputs;
using AS.EX.Console.Inputs.Interfaces;
using AS.EX.Data.ExcelData;
using AS.EX.Data.ExcelData.Analyzers;

namespace AS.EX.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(@"Start Excel Program");

            IInput input = new ConsoleInput();
            input.StartInput();

            CellTable table = new CellTable(input.RowCount, input.ColumnCount);

            foreach (Cell cell in input.Cells)
            {
                ExcelCellAnalyzer.SetCellParameters(cell);
                table.AddCell(cell);
            }

            table.CalculateCells();


            foreach (Cell cell in table.Cells)
            {
                System.Console.WriteLine(cell.ToString());
            }

            System.Console.WriteLine(@"End work");
            System.Console.ReadLine();
        }
    }
}
