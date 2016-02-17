using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Interfaces
{
    public interface ICellProperties : IProperties
    {
        bool IsCalculated { get; set; }
        CellTypeEnum Type { get; set; }

        string Value { get; set; }
    }
}