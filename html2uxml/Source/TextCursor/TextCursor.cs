namespace htmlDocument.Source;

public class TextCursor : ITextCursor
{
    private readonly string _content;
    private int _currentIndex;
#if DEBUG
    private char CurrentSymbol => _content[_currentIndex];
#endif

    public TextCursor(TextCursor textCursor) : this(
        textCursor._content.Substring(textCursor._currentIndex, textCursor._content.Length - 1)
    )
    {
    }

    public TextCursor(string content)
    {
        _content = content ?? throw new ArgumentNullException(content);
        if (_content.Length == 0)
            throw new ArgumentOutOfRangeException(nameof(content), "Content length should be greater zero!");
    }

    public char Current() => Value(_currentIndex);

    public bool CanIterateNext() => _currentIndex + 1 != _content.Length && _currentIndex != _content.Length;

    public bool CanIteratePrev() => _currentIndex - 1 >= 0;

    public char Prev() => Value(_currentIndex - 1);

    public char Next() => Value(_currentIndex + 1);

    public void IteratePrev() => _currentIndex--;

    public void IterateNext() => _currentIndex++;

    private char Value(int index) => _content[index];
}