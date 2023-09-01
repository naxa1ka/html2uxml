using System.Text;
using html2uxmlSharpDev.source.htmlDocument.Source;

namespace htmlDocument.Source;

public class SelfClosingTag : ITag
{
    public IEnumerable<ITag> Children => Enumerable.Empty<ITag>();
    public IEnumerable<IAttribute> Attributes => _attributes;
    public string Content => string.Empty;
    public string Name { get; }

    private readonly List<IAttribute> _attributes = new();
    
    public SelfClosingTag(string name, IEnumerable<IAttribute> attributes)
    {
        Name = name;
        _attributes.AddRange(attributes);
    }

    public string AsString()
    {
        var attributesAsString = new Attributes(_attributes).AsString();
        return $"<{Name} {attributesAsString} />\n";
    }
}