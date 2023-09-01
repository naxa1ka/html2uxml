using html2uxmlSharpDev.source.Command;
using htmlDocument.Source;

namespace html2uxmlSharpDev.source.InternalTextCursor;

internal class CloseTagCommand : ICommand
{
    private readonly ITextCursor _textCursor;

    public CloseTagCommand(ITextCursor textCursor) => _textCursor = textCursor;

    public void Execute()
    {
        GoToCloseTagBracketCommand();
        if (_textCursor.CanIterateNext())
            _textCursor.IterateNext();
    }

    private void GoToCloseTagBracketCommand()
    {
        new LoopedTextCursor(
            new TextCursorWithCondition(
                _textCursor,
                new NotEqualsSymbolIterateCondition(
                    new CloseTagBracketSymbol()
                )
            )
        ).IterateNext();
    }
}