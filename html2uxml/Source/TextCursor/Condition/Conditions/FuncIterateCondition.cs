namespace htmlDocument.Source;

public class FuncIterateCondition : IIterateCondition
{
    private readonly Func<char, bool> _condition;

    public FuncIterateCondition(Func<char, bool> condition) => _condition = condition;

    public bool CanIterate(char symbol) => _condition.Invoke(symbol);
}