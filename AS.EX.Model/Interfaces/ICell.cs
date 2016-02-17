using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Interfaces
{
    public interface ICell : IProperties
    {
        int ColumnIndex { get; set; }
        int RowIndex { get; set; }
        CellTypeEnum Type { get; set; }
        string Value { get; set; }
        bool IsCalculated { get; set; }
        bool IsHasReferenceToItself();
        void SetErrorValue(string message);
        string GetCellCoordinate();
        void CheckReferenceToItSelf();
    }
}