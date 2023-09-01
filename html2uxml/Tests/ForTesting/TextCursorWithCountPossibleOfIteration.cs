using htmlDocument.Source;

namespace html2uxmlSharpDev;

internal class TextCursorWithCountPossibleOfIteration : ITextCursor
{
    private int _count;

    public TextCursorWithCountPossibleOfIteration(int count) => _count = count;

    public char Prev() => throw new NotImplementedException();

    public char Next() => throw new NotImplementedException();

    public char Current() => throw new NotImplementedException();

    public bool CanIterateNext() => _count != 0;

    public bool CanIteratePrev() => _count != 0;

    public void IteratePrev() => _count--;

    public void IterateNext() => _count--;
}