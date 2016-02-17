using AS.EX.Model.Interfaces;
using System.Collections.Generic;

namespace AS.EX.Console.Inputs.Interfaces
{
    public interface IInput
    {
        List<ICell> Cells { get; }

        int ColumnCount { get; set; }

        int RowCount { get; set; }

        void StartInput();
    }
}