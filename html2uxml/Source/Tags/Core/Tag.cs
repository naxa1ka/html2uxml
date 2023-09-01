using System.Text;
using html2uxml.Source.Tags.Core;
using html2uxmlSharpDev.source.htmlDocument.Source;

namespace htmlDocument.Source;

public class Tag : ITag
{
    public IEnumerable<ITag> Children => _children;
    public IEnumerable<IAttribute> Attributes => _attributes;
    public string Name { get; }
    public string Content { get; }

    private readonly List<ITag> _children = new();
    private readonly List<IAttribute> _attributes = new();

    public Tag(string name, IEnumerable<ITag> children, IEnumerable<IAttribute> attributes)
        : this(name, string.Empty, children, attributes)
    {
    }

    public Tag(string name, string content, IEnumerable<IAttribute> attributes)
        : this(name, content, Enumerable.Empty<ITag>(), attributes)
    {
    }

    public Tag(string name, string content, IEnumerable<ITag> children, IEnumerable<IAttribute> attributes)
    {
        Name = name;
        Content = content;
        _children.AddRange(children);
        _attributes.AddRange(attributes);
    }

    public string AsString()
    {
        var sb = new StringBuilder();

        sb.Append($"<{Name}");
        sb.Append(AttributeAsString());
        sb.Append('>');
        sb.Append(ContentAsString());
        sb.Append($"</{Name}>");

        return sb.ToString();
    }

    private string AttributeAsString()
    {
        var hasAttributes = _attributes.Any();
        if (hasAttributes)
        {
            var attributesAsString = new Attributes(_attributes).AsString();
            return $" {attributesAsString}";
        }
        return string.Empty;
    }

    private string ContentAsString()
    {
        var hasChildren = _children.Any();
        if (hasChildren)
            return new TagsAsString(_children).Value();
        return Content;
    }
}