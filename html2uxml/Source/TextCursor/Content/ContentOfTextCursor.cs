using System.Text;
using html2uxml.Source.String;

namespace htmlDocument.Source;

public class ContentOfTextCursor
{
    private readonly ITextCursor _textCursor;

    public ContentOfTextCursor(ITextCursor textCursor) => _textCursor = textCursor;

    public string ContentNextWithCurrentSymbol() => Current() + ContentNext();

    public string ContentNext()
    {
        var sb = new StringBuilder();
        while (CanIterateNext())
        {
            IterateNext();
            sb.Append(Current());
        }

        return sb.ToString();
    }

    public string ContentPrevWithCurrentSymbol()
    {
        var current = Current();
        return ContentPrev() + current;
    }

    public string ContentPrev()
    {
        var sb = new StringBuilder();
        while (CanIteratePrev())
        {
            IteratePrev();
            sb.Append(Current());
        }

        return sb.ToString().Reverse();
    }

    private char Current() => _textCursor.Current();

    private bool CanIterateNext() => _textCursor.CanIterateNext();

    private bool CanIteratePrev() => _textCursor.CanIteratePrev();

    private void IteratePrev() => _textCursor.IteratePrev();

    private void IterateNext() => _textCursor.IterateNext();
}