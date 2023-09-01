namespace htmlDocument.Source;

public class NotEqualsSymbolIterateCondition : IIterateCondition
{
    private readonly ISymbol _symbol;

    public NotEqualsSymbolIterateCondition(ISymbol symbol) => _symbol = symbol;

    public bool CanIterate(char symbol) => !_symbol.Equals(symbol);
}