using System.Collections.Generic;
using AS.EX.Model.Interfaces;

namespace AS.EX.Console.Inputs.Interfaces
{
    public interface IInput
    {
        void StartInput();
        int RowCount { get; set; }
        int ColumnCount { get; set; }
        List<ICell> Cells { get; }
    }
}