using htmlDocument.Source;
using NUnit.Framework;

namespace html2uxmlSharpDev;

public class LoopedTextCursorTests
{
    [Test]
    public void WhenIterateNext_AndCountOfPossibleIterationEqualTwo_ThenShouldIterateTwice()
    {
        // Arrange.
        var counterOfCalls = 0;
        const int expected = 2;
        var textCursor = new LoopedTextCursor(
            new TextCursorWithCallbacksOnIteration(
                new TextCursorWithCountPossibleOfIteration(expected),
                () => counterOfCalls++,
                null
            )
        );

        // Act.
        textCursor.IterateNext();

        // Assert.
        Assert.That(counterOfCalls, Is.EqualTo(expected));
    }

    [Test]
    public void WhenIteratePrev_AndCountOfPossibleIterationEqualTwo_ThenShouldIterateTwice()
    {
        // Arrange.
        var counterOfCalls = 0;
        const int expected = 2;
        var textCursor = new LoopedTextCursor(
            new TextCursorWithCallbacksOnIteration(
                new TextCursorWithCountPossibleOfIteration(expected),
                null,
                () => counterOfCalls++
            )
        );

        // Act.
        textCursor.IteratePrev();

        // Assert.
        Assert.That(counterOfCalls, Is.EqualTo(expected));
    }

    [Test]
    public void WhenIterateNext_AndCantIterateNext_ThenShouldNotIterate()
    {
        // Arrange.
        var textCursor = new CantIterateTextCursor();
        var loopedTextCursor = new LoopedTextCursor(textCursor);

        // Act.
        void Iterate() => loopedTextCursor.IterateNext();

        // Assert.
        Assert.DoesNotThrow(Iterate);
    }

    [Test]
    public void WhenIteratePrev_AndCantIteratePrev_ThenShouldNotIterate()
    {
        // Arrange.
        var textCursor = new CantIterateTextCursor();
        var loopedTextCursor = new LoopedTextCursor(textCursor);

        // Act.
        void Iterate() => loopedTextCursor.IteratePrev();

        // Assert.
        Assert.DoesNotThrow(Iterate);
    }
}