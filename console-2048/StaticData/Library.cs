namespace console_2048.StaticData;

public class Library
{
    public readonly Cell CellDefault;
    public readonly List<Field> FieldsAll;
    public Library()
    {
        CellDefault = Configs.Get<Cell>("default");
        FieldsAll = Configs.GetAll<Field>();
    }
}