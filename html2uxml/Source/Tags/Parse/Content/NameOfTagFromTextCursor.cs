using htmlDocument.Source;

namespace html2uxmlSharpDev.source.InternalTextCursor;

internal class NameOfTagFromTextCursor
{
    private readonly ITextCursor _textCursor;

    public NameOfTagFromTextCursor(ITextCursor textCursor)
    {
        _textCursor = textCursor;
    }

    public string Value()
    {
        return new ContentOfTextCursor(
            new TextCursorWithPeekNextCondition(_textCursor,
                new AndIterateCondition(
                    new NotEqualsSymbolIterateCondition(
                        new CloseTagBracketSymbol()
                    ),
                    new NotEqualsSymbolIterateCondition(
                        new AttributesSeparatorSymbol()
                    )
                )
            )
        ).ContentNextWithCurrentSymbol();;
    }
}