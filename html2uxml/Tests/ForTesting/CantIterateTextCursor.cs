using htmlDocument.Source;

namespace html2uxmlSharpDev;

internal class CantIterateTextCursor : ITextCursor
{
    public char Prev() => throw new NotImplementedException();
    public char Next() => throw new NotImplementedException();
    public char Current() => throw new NotImplementedException();
    public bool CanIterateNext() => false;
    public bool CanIteratePrev() => false;
    public void IteratePrev() => throw new NotImplementedException();
    public void IterateNext() => throw new NotImplementedException();
}