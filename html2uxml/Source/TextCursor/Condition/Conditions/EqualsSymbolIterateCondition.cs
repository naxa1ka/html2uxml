namespace htmlDocument.Source;

public class EqualsSymbolIterateCondition : IIterateCondition
{
    private readonly ISymbol _symbol;

    public EqualsSymbolIterateCondition(ISymbol symbol) => _symbol = symbol;

    public bool CanIterate(char symbol) => _symbol.Equals(symbol);
}