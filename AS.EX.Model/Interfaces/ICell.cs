using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Interfaces
{
    public interface ICell : IProperties
    {
        int ColumnIndex { get; set; }
        bool IsCalculated { get; set; }
        int RowIndex { get; set; }
        CellTypeEnum Type { get; set; }
        string Value { get; set; }

        void CheckReferenceToItSelf();

        string GetCellCoordinate();

        bool IsHasReferenceToItself();

        void SetErrorValue(string message);
    }
}