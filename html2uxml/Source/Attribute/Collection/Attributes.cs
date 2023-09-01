using System.Text;
using html2uxmlSharpDev.Attribute;
using htmlDocument.Source;

namespace html2uxmlSharpDev.source.htmlDocument.Source;

public class Attributes : IAttributes
{
    private readonly List<IAttribute> _items;

    public IEnumerable<IAttribute> Value => _items;

    public Attributes(IEnumerable<IAttribute> items) => _items = items.ToList();

    /// <summary>
    /// The content represents a sequence of attributes - <see cref="Value"/>; without opening &lt; and closing tags &gt;.
    /// </summary>
    /// <param name="content">A string containing a sequence of attributes.</param>
    /// <example>You can see in <see cref="AttributesTest"/></example>
    public Attributes(string content) : this(ItemsFromContent(content))
    {
        
    }

    public string AsString()
    {
        var sb = new StringBuilder();
        foreach (var x in _items)
            sb.Append(x.AsString());
        return sb.ToString();
    }
    
    private static List<IAttribute> ItemsFromContent(string content)
    {
        if (string.IsNullOrEmpty(content))
            return new List<IAttribute>();

        var textCursor = new TextCursor(content);
        var attributes = new List<IAttribute>();
        while (textCursor.CanIterateNext())
        {
            IterateWhileNotLetter(textCursor);
            var name = NameOfAttribute(textCursor);
            IterateWhileNotOpenValueSymbolOfAttribute(textCursor);
            var value = ValueOfAttribute(textCursor);
            CloseAttribute(textCursor);
            attributes.Add(new Attribute(name, value));
        }

        return attributes;
    }
    
    private static void IterateWhileNotLetter(ITextCursor textCursor)
    {
        new LoopedTextCursor(
            new TextCursorWithCondition(
                textCursor,
                new NotEqualsSymbolIterateCondition(
                    new LetterSymbol()
                )
            )
        ).IterateNext();
    }

    private static string NameOfAttribute(ITextCursor textCursor)
    {
        var condition = new EqualsSymbolIterateCondition(
            new LetterSymbol()
        );
        return new ContentOfTextCursor(
            new TextCursorWithCondition(
                new TextCursorWithPeekNextCondition(
                    textCursor,
                    condition
                ),
                condition
            )
        ).ContentNextWithCurrentSymbol();
    }

    private static void IterateWhileNotOpenValueSymbolOfAttribute(ITextCursor textCursor)
    {
        new LoopedTextCursor(
            new TextCursorWithCondition(
                textCursor,
                new NotEqualsSymbolIterateCondition(
                    new OpenAttributeValueSymbol()
                )
            )
        ).IterateNext();
    }

    private static string ValueOfAttribute(ITextCursor textCursor)
    {
        return new ContentOfTextCursor(
            new TextCursorWithPeekNextCondition(
                textCursor,
                new NotEqualsSymbolIterateCondition(
                    new CloseAttributeValueSymbol()
                )
            )
        ).ContentNext();
    }

    private static void CloseAttribute(ITextCursor textCursor)
    {
        textCursor.IterateNext();
    }
}