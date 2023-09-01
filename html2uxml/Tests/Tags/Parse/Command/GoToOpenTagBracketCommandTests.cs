using html2uxmlSharpDev.source.InternalTextCursor;
using htmlDocument.Source;
using NUnit.Framework;

namespace html2uxmlSharpDev.InternalTextCursor;

public class GoToOpenTagBracketCommandTests
{
    [Test]
    public void WhenIterate_AndCursorOnOpenTag_ThenCursorShouldNotIterate()
    {
        // Arrange.
        var textCursor = new TextCursor("< ");
        var targetTextCursor = new GoToOpenTagBracketCommand(textCursor);

        // Act.
        targetTextCursor.Execute();
        
        // Assert.
        Assert.That(textCursor.Current().ToString(), Is.EqualTo("<"));
    }

    [Test]
    public void WhenIterate_AndCursorBeforeOpenTag_ThenCursorShouldIterateOnce()
    {
        // Arrange.
        var textCursor = new TextCursor(" < ");
        var targetTextCursor = new GoToOpenTagBracketCommand(textCursor);

        // Act.
        targetTextCursor.Execute();
        
        // Assert.
        Assert.That(textCursor.Current().ToString(), Is.EqualTo("<"));
    }
}