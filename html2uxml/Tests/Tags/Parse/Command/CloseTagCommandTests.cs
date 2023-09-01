using html2uxmlSharpDev.source.InternalTextCursor;
using htmlDocument.Source;
using NUnit.Framework;

namespace html2uxmlSharpDev.InternalTextCursor;

public class CloseTagCommandTests
{
    [Test]
    public void WhenExecute_ThenShouldIterateToFirstCloseTagAndIterateNext()
    {
        // Arrange.
        var textCursor = new TextCursor("<div>x</div>");
        var closeTagCommand = new CloseTagCommand(textCursor);

        // Act.
        closeTagCommand.Execute();

        // Assert.
        Assert.That(textCursor.Current(), Is.EqualTo('x'));
        Assert.That(textCursor.Prev(), Is.EqualTo('>'));
    }
    
    [Test]
    public void WhenExecute_AndAfterCloseTagNothing_ThenCurrentShouldReturnCloseTag()
    {
        // Arrange.
        var textCursor = new TextCursor("</div>");
        var closeTagCommand = new CloseTagCommand(textCursor);

        // Act.
        closeTagCommand.Execute();

        // Assert.
        Assert.That(textCursor.Current(), Is.EqualTo('>'));
    }
}