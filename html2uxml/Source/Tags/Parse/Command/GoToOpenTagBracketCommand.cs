using html2uxmlSharpDev.source.Command;
using htmlDocument.Source;

namespace html2uxmlSharpDev.source.InternalTextCursor;

internal class GoToOpenTagBracketCommand : ICommand
{
    private readonly ITextCursor _textCursor;

    public GoToOpenTagBracketCommand(ITextCursor textCursor) => _textCursor = textCursor;

    public void Execute()
    {
        new LoopedTextCursor(
            new TextCursorWithCondition(
                _textCursor,
                new NotEqualsSymbolIterateCondition(
                    new OpenTagBracketSymbol()
                )
            )
        ).IterateNext();
    }
}