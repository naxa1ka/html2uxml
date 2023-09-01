namespace htmlDocument.Source;

public class OrIterateCondition : IIterateCondition
{
    private readonly IIterateCondition _first;
    private readonly IIterateCondition _second;

    public OrIterateCondition(IIterateCondition first, IIterateCondition second)
    {
        _first = first;
        _second = second;
    }

    public bool CanIterate(char symbol) => _first.CanIterate(symbol) || _second.CanIterate(symbol);
}