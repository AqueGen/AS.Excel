using System.Collections.Generic;
using AS.EX.Console.Inputs;
using AS.EX.Console.Inputs.Interfaces;
using AS.EX.Console.Outputs;
using AS.EX.Console.Outputs.Interfaces;
using AS.EX.Model.Excel.Data;
using AS.EX.Model.Excel.Data.Cells;
using AS.EX.Model.Excel.Data.Cells.Properties;
using AS.EX.Model.Interfaces;

namespace AS.EX.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(@"Start Excel Program");

            IInput input = new ConsoleInput();

            input.RowCount = 4;
            input.ColumnCount = 4;

            input.StartInput();

            ITable table = new CellTable();
            //List<ICellProperties> propertieses = new List<ICellProperties>
            //{
            //    new CellProperties("12"),                
            //    new CellProperties("=C2"),
            //    new CellProperties("3"),
            //    new CellProperties("'Sample"),
            //    new CellProperties("=A1+B1*C1/5"),
            //    new CellProperties("=A2*B1"),
            //    new CellProperties("=B3-C3"),
            //    new CellProperties("'Spread"),
            //    new CellProperties("'Test"),
            //    new CellProperties("=4-3"),
            //    new CellProperties("5"),
            //    new CellProperties("'Sheet")
            //};

            //List<ICellProperties> propertieses = new List<ICellProperties>
            //{
            //    new CellProperties("1"),
            //    new CellProperties("=A1*5-7*A1"),
            //    new CellProperties("3"),
            //    new CellProperties("'Sample"),
            //};

            //foreach (var properti in propertieses)
            //{
            //    properti.SetupProperties();
            //}


            //List<ICell> cells = new List<ICell>
            //{
            //    new Cell(0, 0, propertieses[0]),
            //    new Cell(1, 0, propertieses[1]),
            //    new Cell(2, 0, propertieses[2]),
            //    new Cell(3, 0, propertieses[3]),
            //};

            //foreach (ICell cell in cells)
            //{
                
            //    input.Cells.Add(cell);
            //}



            foreach (ICell cell in input.Cells)
            {
                cell.SetupProperties();
                table.AddCell(cell);
                System.Console.WriteLine("Add -> " + cell);
            }
            System.Console.WriteLine();

            table.CalculateCells();

            //Output cells in console
            foreach (ICell cell in table.Cells)
            {
                System.Console.WriteLine(cell.ToString());
            }
            System.Console.WriteLine();

            System.Console.WriteLine("-----Result-----");
            IOutput output = new ConsoleOutput(input.RowCount, input.ColumnCount, table.Cells);
            output.StartOutput();
            System.Console.WriteLine("-----Result-----");

            System.Console.ReadLine();
        }
    }
}
