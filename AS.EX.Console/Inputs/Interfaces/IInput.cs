using System.Collections.Generic;
using AS.EX.Data.ExcelData;

namespace AS.EX.Console.Inputs.Interfaces
{
    public interface IInput
    {
        void StartInput();
        int RowCount { get; }
        int ColumnCount { get; }
        List<Cell> Cells { get; } 
    }
}