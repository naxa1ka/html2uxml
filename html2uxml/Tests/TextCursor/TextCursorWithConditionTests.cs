using htmlDocument.Source;
using NUnit.Framework;

namespace html2uxmlSharpDev;

public class TextCursorWithConditionTests
{
    [Test]
    public void WhenCanIterateNext_AndIterateConditionReturnFalse_ThenShouldReturnFalse()
    {
        // Arrange.
        var textCursor = new TextCursor("hello");
        var textCursorWithCondition = new TextCursorWithCondition(
            textCursor,
            new FuncIterateCondition(_ => false)
        );

        // Act.
        var can = textCursorWithCondition.CanIterateNext();

        // Assert.
        Assert.That(can, Is.EqualTo(false));
    }

    [Test]
    public void WhenCanIteratePrev_AndIterateConditionReturnFalse_ThenShouldReturnFalse()
    {
        // Arrange.
        var textCursor = new TextCursor("hello");
        var textCursorWithCondition = new TextCursorWithCondition(
            textCursor,
            new FuncIterateCondition(_ => false)
        );

        // Act.
        var can = textCursorWithCondition.CanIteratePrev();

        // Assert.
        Assert.That(can, Is.EqualTo(false));
    }

    [Test]
    public void WhenCanIterateNext_AndIterateConditionReturnFalseForCurrentSymbol_ThenShouldReturnFalse()
    {
        // Arrange.
        var textCursor = new TextCursorWithCondition(
            new TextCursor("hello"),
            new FuncIterateCondition(c => !c.Equals('h'))
        );

        // Act.
        var can = textCursor.CanIterateNext();

        // Assert.
        Assert.That(can, Is.EqualTo(false));
    }

    [Test]
    public void WhenCanIteratePrev_AndIterateConditionReturnFalseForCurrentSymbol_ThenShouldReturnFalse()
    {
        // Arrange.
        var sourceTextCursor = new TextCursor("hello");
        var textCursor = new TextCursorWithCondition(
            sourceTextCursor,
            new FuncIterateCondition(c => !c.Equals('e'))
        );
        sourceTextCursor.IterateNext();

        // Act.
        var can = textCursor.CanIteratePrev();

        // Assert.
        Assert.That(can, Is.EqualTo(false));
    }

    [Test]
    public void WhenCanIterateNext_AndIterateConditionReturnFalseForNextSymbol_ThenShouldReturnTrue()
    {
        // Arrange.
        var textCursor = new TextCursorWithCondition(
            new TextCursor("hello"),
            new FuncIterateCondition(c => !c.Equals('e'))
        );

        // Act.
        var can = textCursor.CanIterateNext();

        // Assert.
        Assert.That(can, Is.EqualTo(true));
    }
    
    [Test]
    public void WhenCanIteratePrev_AndIterateConditionReturnFalseForPrevSymbol_ThenShouldReturnTrue()
    {
        // Arrange.
        var sourceTextCursor = new TextCursor("hello");
        while (sourceTextCursor.CanIterateNext()) 
            sourceTextCursor.IterateNext();
        var textCursor = new TextCursorWithCondition(
            sourceTextCursor,
            new FuncIterateCondition(c => !c.Equals('l'))
        );

        // Act.
        var can = textCursor.CanIteratePrev();

        // Assert.
        Assert.That(can, Is.EqualTo(true));
    }
}