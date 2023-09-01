using htmlDocument.Source;

namespace html2uxmlSharpDev;

    internal class TextCursorWithCallbacksOnIteration : ITextCursor
    {
        private readonly ITextCursor _textCursor;
        private readonly Action? _onIterateNext;
        private readonly Action? _onIteratePrev;

        public TextCursorWithCallbacksOnIteration(
            ITextCursor textCursor,
            Action? onIterateNext,
            Action? onIteratePrev)
        {
            _textCursor = textCursor;
            _onIterateNext = onIterateNext;
            _onIteratePrev = onIteratePrev;
        }

        public char Prev() => _textCursor.Prev();

        public char Next() => _textCursor.Next();

        public char Current() => _textCursor.Current();

        public bool CanIterateNext() => _textCursor.CanIterateNext();

        public bool CanIteratePrev() => _textCursor.CanIteratePrev();

        public void IteratePrev()
        {
            _onIteratePrev?.Invoke();
            _textCursor.IteratePrev();
        }

        public void IterateNext()
        {
            _onIterateNext?.Invoke();
            _textCursor.IterateNext();
        }
    }