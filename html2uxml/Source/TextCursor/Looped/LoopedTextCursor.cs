namespace htmlDocument.Source;

public class LoopedTextCursor : ITextCursor
{
    private readonly ITextCursor _textCursor;

    public LoopedTextCursor(ITextCursor textCursor) => _textCursor = textCursor;

    public char Prev() => _textCursor.Prev();

    public char Next() => _textCursor.Next();

    public char Current() => _textCursor.Current();

    public bool CanIterateNext() => _textCursor.CanIterateNext();

    public bool CanIteratePrev() => _textCursor.CanIteratePrev();

    public void IteratePrev()
    {
        while (CanIteratePrev())
            _textCursor.IteratePrev();
    }

    public void IterateNext()
    {
        while (CanIterateNext())
            _textCursor.IterateNext();
    }
}