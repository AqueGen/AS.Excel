using System.Collections.Generic;
using AS.EX.Model.Excel.Data.Cells;

namespace AS.EX.Model.Interfaces
{
    public interface ITable
    {
        void AddCell(ICell cell);
        void CalculateCells();
        List<ICell> Cells { get;} 
    }
}