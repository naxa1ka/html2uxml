namespace htmlDocument.Source;

public class LetterSymbol : ISymbol
{
    public bool Equals(char other) => char.IsLetter(other);

    public bool NotEquals(char other) => !Equals(other);
}