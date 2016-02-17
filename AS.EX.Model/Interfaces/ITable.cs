using System.Collections.Generic;

namespace AS.EX.Model.Interfaces
{
    public interface ITable
    {
        List<ICell> Cells { get; }

        void AddCell(ICell cell);

        void CalculateCells();

        ICell GetCell(string cellReference);
    }
}