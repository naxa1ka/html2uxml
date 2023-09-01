namespace htmlDocument.Source;

public class TextCursorWithPeekNextCondition : ITextCursor
{
    private readonly ITextCursor _textCursor;
    private readonly IIterateCondition _iterateCondition;

    public TextCursorWithPeekNextCondition(ITextCursor textCursor, IIterateCondition iterateCondition)
    {
        _textCursor = textCursor;
        _iterateCondition = iterateCondition;
    }
    
    public bool CanIterateNext() => _textCursor.CanIterateNext() && _iterateCondition.CanIterate(Next());
    
    public bool CanIteratePrev() => _textCursor.CanIteratePrev() && _iterateCondition.CanIterate(Prev());
    
    public char Prev() => _textCursor.Prev();
    
    public char Next() => _textCursor.Next();
    
    public char Current() => _textCursor.Current();
    
    public void IteratePrev() => _textCursor.IteratePrev();
    
    public void IterateNext() => _textCursor.IterateNext();
}