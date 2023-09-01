namespace htmlDocument.Source;

public class AndIterateCondition : IIterateCondition
{
    private readonly IIterateCondition _first;
    private readonly IIterateCondition _second;

    public AndIterateCondition(IIterateCondition first, IIterateCondition second)
    {
        _first = first;
        _second = second;
    }

    public bool CanIterate(char symbol) => _first.CanIterate(symbol) && _second.CanIterate(symbol);
}