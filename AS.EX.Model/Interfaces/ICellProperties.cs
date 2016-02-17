using AS.EX.Model.Excel.EnumTypes;

namespace AS.EX.Model.Interfaces
{
    public interface ICellProperties : IProperties
    {
        CellTypeEnum Type { get; set; }

        string Value { get; set; }

        bool IsCalculated { get; set; }
    }
}