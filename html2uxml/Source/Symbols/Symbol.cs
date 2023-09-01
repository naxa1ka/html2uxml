namespace htmlDocument.Source;

public class Symbol : ISymbol
{
    private readonly char _symbol;

    public Symbol(char symbol) => _symbol = symbol;

    public bool Equals(char other) => other.Equals(_symbol);

    public bool NotEquals(char other) => !Equals(other);
}