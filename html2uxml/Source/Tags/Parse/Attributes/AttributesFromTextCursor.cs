using html2uxmlSharpDev.source.htmlDocument.Source;
using htmlDocument.Source;

namespace html2uxmlSharpDev.source.InternalTextCursor;

internal class AttributesFromTextCursor
{
    private readonly ITextCursor _textCursor;

    public AttributesFromTextCursor(ITextCursor textCursor)
    {
        _textCursor = textCursor;
    }

    public IAttributes Value()
    {
        if (new CloseTagSymbol().Equals(_textCursor.Current()))
            return new EmptyAttributes();

        return new Attributes(
            new TreatmentContentForAttributes(
                new ContentOfTextCursor(
                    new TextCursorWithPeekNextCondition(_textCursor,
                        new NotEqualsSymbolIterateCondition(
                            new CloseTagBracketSymbol()
                        )
                    )
                ).ContentNext()
            ).Value()
        );
    }
}