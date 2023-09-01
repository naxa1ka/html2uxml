using System.Text;
using htmlDocument.Source;

namespace html2uxml.Source.Tags.Core;

public class TagsAsString 
{
    private readonly IEnumerable<ITag> _tags;

    public TagsAsString(IEnumerable<ITag> tags) => _tags = tags;

    public string Value()
    {
        if (!_tags.Any())
            return string.Empty;
        
        var sb = new StringBuilder();
        foreach (var child in _tags)
            sb.Append(child.AsString());
        
        return sb.ToString();
    }
}