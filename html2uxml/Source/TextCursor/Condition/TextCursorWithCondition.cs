namespace htmlDocument.Source;

public class TextCursorWithCondition : ITextCursor
{
    private readonly ITextCursor _textCursor;
    private readonly IIterateCondition _iterateCondition;

    public TextCursorWithCondition(
        ITextCursor textCursor,
        IIterateCondition iterateCondition)
    {
        _textCursor = textCursor;
        _iterateCondition = iterateCondition;
    }

    public bool CanIterateNext() => _textCursor.CanIterateNext() && _iterateCondition.CanIterate(Current());
    
    public bool CanIteratePrev() => _textCursor.CanIteratePrev() && _iterateCondition.CanIterate(Current());

    public char Prev() => _textCursor.Prev();
    
    public char Next() => _textCursor.Next();
    
    public char Current() => _textCursor.Current();
    
    public void IteratePrev() => _textCursor.IteratePrev();
    
    public void IterateNext() => _textCursor.IterateNext();
}