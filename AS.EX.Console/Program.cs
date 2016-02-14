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
            //input.StartInput();

            CellTable table = new CellTable(input.RowCount, input.ColumnCount);

            input.Cells.Add(new Cell(0, 0) { Value = "12a" });
            input.Cells.Add(new Cell(1, 0) { Value = "=C2" });
            input.Cells.Add(new Cell(2, 0) { Value = "3" });
            input.Cells.Add(new Cell(3, 0) { Value = "'Sample" });
            input.Cells.Add(new Cell(0, 1) { Value = "=A1+B1*C1/5" });
            input.Cells.Add(new Cell(1, 1) { Value = "=A2*B1" });
            input.Cells.Add(new Cell(2, 1) { Value = "=B3-C3" });
            input.Cells.Add(new Cell(3, 1) { Value = "'Spread" });
            input.Cells.Add(new Cell(0, 2) { Value = "'Test" });
            input.Cells.Add(new Cell(1, 2) { Value = "=4-3" });
            input.Cells.Add(new Cell(2, 2) { Value = "5" });
            input.Cells.Add(new Cell(3, 2) { Value = "'Sheet" });



            foreach (Cell cell in input.Cells)
            {
                ExcelCellAnalyzer.SetParametersForCell(cell);
                table.AddCell(cell);
            }

            table.CalculateCells();

            //Output cells in console
            foreach (Cell cell in table.Cells)
            {
                System.Console.WriteLine(cell.ToString());
            }

            System.Console.WriteLine(@"End work");
            System.Console.ReadLine();
        }
    }
}
