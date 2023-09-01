using html2uxmlSharpDev.InternalTextCursor;
using html2uxmlSharpDev.source.htmlDocument.Source;
using html2uxmlSharpDev.source.InternalTextCursor;
using htmlDocument.Source;

namespace html2uxmlSharpDev.source.Tags;

public class TagFromTextCursor
{
    private readonly ITextCursor _textCursor;

    public TagFromTextCursor(ITextCursor textCursor) => _textCursor = textCursor;

    public ITag Value()
    {
        new GoToOpenTagBracketCommand(_textCursor).Execute();
        new GoToStartTagNameCommand(_textCursor).Execute();

        var tagName = new NameOfTagFromTextCursor(_textCursor).Value();
        var attributes = new AttributesFromTextCursor(_textCursor).Value();

        if (new SelfClosingTags().IsTagSelfClosing(tagName))
        {
            new CloseTagCommand(_textCursor).Execute();
            return new SelfClosingTag(tagName, attributes.Value);
        }

        new GoToContentTagNameCommand(_textCursor).Execute();
        var content = new ContentOfTagFromTextCursor(_textCursor).Value();
        new GoToOpenTagBracketCommand(_textCursor).Execute();

        var isTagHasNotChild = new CloseTagSymbol().Equals(_textCursor.Next());
        if (isTagHasNotChild)
        {
            new CloseTagCommand(_textCursor).Execute();
            return new Tag(tagName, content, attributes.Value);
        }

        var childrenTags = new ChildrenTagsFromTextCursor(_textCursor).Value();
        new CloseTagCommand(_textCursor).Execute();
        
        return new Tag(tagName, childrenTags, attributes.Value);
    }
}