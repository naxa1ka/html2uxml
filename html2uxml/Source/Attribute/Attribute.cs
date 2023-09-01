namespace html2uxmlSharpDev.source.htmlDocument.Source;

public class Attribute : IAttribute
{
    public string Name { get; }
    public string Value { get; }
    
    public Attribute(string name, string value)
    {
        Name = name;
        Value = value;
    }
    
    public string AsString() => $"{Name}=\"{Value}\"";
}