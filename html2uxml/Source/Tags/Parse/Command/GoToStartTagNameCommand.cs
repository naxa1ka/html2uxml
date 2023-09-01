using html2uxmlSharpDev.source.Command;
using htmlDocument.Source;

namespace html2uxmlSharpDev.InternalTextCursor;

public class GoToStartTagNameCommand : ICommand
{
    private readonly ITextCursor _textCursor;

    public GoToStartTagNameCommand(ITextCursor textCursor) => _textCursor = textCursor;

    public void Execute() => _textCursor.IterateNext();
}