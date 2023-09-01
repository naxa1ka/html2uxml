using html2uxmlSharpDev.source.Tags;
using htmlDocument.Source;

namespace html2uxmlSharpDev.source.InternalTextCursor;

public class ChildrenTagsFromTextCursor
{
    private readonly ITextCursor _textCursor;

    public ChildrenTagsFromTextCursor(ITextCursor textCursor) => _textCursor = textCursor;

    public IEnumerable<ITag> Value()
    {
        var childrenTags = new List<ITag>();
        do
        {
            childrenTags.Add(new TagFromTextCursor(_textCursor).Value());
            GoToNextChildOrCloseTagSymbol();
        } while (IsParentTagClosed());

        return childrenTags;
    }

    private void GoToNextChildOrCloseTagSymbol() => new GoToOpenTagBracketCommand(_textCursor).Execute();

    private bool IsParentTagClosed() => new CloseTagSymbol().NotEquals(_textCursor.Next());
}