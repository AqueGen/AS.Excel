using AS.EX.Console.Inputs;
using AS.EX.Console.Inputs.Interfaces;
using AS.EX.Model.Excel.Data;
using AS.EX.Model.Excel.Data.Properties;

namespace AS.EX.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(@"Start Excel Program");

            IInput input = new ConsoleInput();
            //input.StartInput();

            CellTable table = new CellTable();


            input.Cells.Add(new Cell(0, 0, new CellProperties("12")));
            input.Cells.Add(new Cell(1, 0, new CellProperties("=C2")));
            input.Cells.Add(new Cell(2, 0, new CellProperties("3")));
            input.Cells.Add(new Cell(3, 0, new CellProperties("'Sample")));
            input.Cells.Add(new Cell(0, 1, new CellProperties("=A1+B1*C1/5")));
            input.Cells.Add(new Cell(1, 1, new CellProperties("=A2*B1")));
            input.Cells.Add(new Cell(2, 1, new CellProperties("=B3-C3")));
            input.Cells.Add(new Cell(3, 1, new CellProperties("'Spread")));
            input.Cells.Add(new Cell(0, 2, new CellProperties("'Test")));
            input.Cells.Add(new Cell(1, 2, new CellProperties("=4-3")));
            input.Cells.Add(new Cell(2, 2, new CellProperties("5")));
            input.Cells.Add(new Cell(3, 2, new CellProperties("'Sheet")));


            //input.Cells.Add(new Cell(0, 0, new CellTypeValue("=B1+C1")));
            //input.Cells.Add(new Cell(1, 0, new CellTypeValue("12")));
            //input.Cells.Add(new Cell(2, 0, new CellTypeValue("3")));
            //input.Cells.Add(new Cell(3, 0, new CellTypeValue("'Sample")));
            //input.Cells.Add(new Cell(0, 1, new CellTypeValue("=A1+B1*C1/5")));

            foreach (Cell cell in input.Cells)
            {
                table.AddCell(cell);
                System.Console.WriteLine("Add -> " + cell);
            }
            System.Console.WriteLine();

            table.CalculateCells();

            //Output cells in console

            System.Console.WriteLine("-----Result-----");
            foreach (Cell cell in table.Cells)
            {
                System.Console.WriteLine(cell.ToString());
            }
            System.Console.WriteLine("-----Result-----");

            System.Console.ReadLine();
        }
    }
}
