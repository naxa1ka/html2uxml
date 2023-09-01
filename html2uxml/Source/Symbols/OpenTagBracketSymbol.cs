﻿namespace htmlDocument.Source;

public class OpenTagBracketSymbol : ISymbol
{
    private readonly ISymbol _symbol = new Symbol('<');

    public bool Equals(char other) => _symbol.Equals(other);

    public bool NotEquals(char other) => _symbol.NotEquals(other);
}