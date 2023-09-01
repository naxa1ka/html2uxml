namespace htmlDocument.Source;

public class OpenAttributeValueSymbol : ISymbol
{
    private readonly ISymbol _symbol;

    public OpenAttributeValueSymbol() => _symbol = new Symbol('"');

    public bool Equals(char other) => _symbol.Equals(other);

    public bool NotEquals(char other) => _symbol.NotEquals(other);
}