using System.Collections.Generic;

namespace AS.EX.Model.Interfaces
{
    public interface ITable
    {
        void AddCell(ICell cell);
        void CalculateCells();
        List<ICell> Cells { get; }

        ICell GetCell(string cellReference);
    }
}