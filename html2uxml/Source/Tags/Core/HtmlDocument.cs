using html2uxmlSharpDev.source.htmlDocument.Source;
using html2uxmlSharpDev.source.Tags;
using htmlDocument.Source;

namespace html2uxml.Source.Tags.Core;

public class HtmlDocument : ITag
{
    private readonly ITag _rootTag;

    public IEnumerable<ITag> Children => _rootTag.Children;
    public IEnumerable<IAttribute> Attributes => _rootTag.Attributes;
    public string Name => _rootTag.Name;
    public string Content => _rootTag.Content;

    public HtmlDocument(string content)
    {
        _rootTag = new TagFromTextCursor(new TextCursor(content)).Value();
    }

    public string AsString() => _rootTag.AsString();
}