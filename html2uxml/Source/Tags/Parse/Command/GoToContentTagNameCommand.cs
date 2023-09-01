using html2uxmlSharpDev.source.Command;
using htmlDocument.Source;

namespace html2uxmlSharpDev.InternalTextCursor;

public class GoToContentTagNameCommand  : ICommand
{
    private readonly ITextCursor _textCursor;

    public GoToContentTagNameCommand(ITextCursor textCursor) => _textCursor = textCursor;

    public void Execute() => _textCursor.IterateNext();
}