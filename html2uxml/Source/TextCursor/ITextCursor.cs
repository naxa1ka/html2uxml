namespace htmlDocument.Source;

public interface ITextCursor 
{
    char Prev();
    char Next();
    char Current();
    bool CanIterateNext();
    bool CanIteratePrev();
    void IteratePrev();
    void IterateNext();
}