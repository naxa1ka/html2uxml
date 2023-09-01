using html2uxmlSharpDev.source.htmlDocument.Source;

namespace htmlDocument.Source;

public interface ITag
{
    IEnumerable<ITag> Children { get; }
    IEnumerable<IAttribute> Attributes { get; }
    string Name { get; }
    string Content { get; }
    string AsString();
}