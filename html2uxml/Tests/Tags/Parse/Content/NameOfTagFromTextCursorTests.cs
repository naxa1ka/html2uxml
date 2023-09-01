using html2uxmlSharpDev.source.InternalTextCursor;
using htmlDocument.Source;
using NUnit.Framework;

namespace html2uxmlSharpDev.InternalTextCursor;

public class NameOfTagFromTextCursorTests
{
    [Test]
    public void WhenValue_AndAfterTagSpace_ThenShouldValueBeTagWithoutSpace()
    {
        // Arrange.
        var textCursor = new TextCursor("<div ");
        textCursor.IterateNext();
        var targetTextCursor = new NameOfTagFromTextCursor(textCursor);
        
        // Act.
        var value = targetTextCursor.Value();

        // Assert.
        Assert.That(value, Is.EqualTo("div"));
    }

    [Test]
    public void WhenValue_ThenCurrentOfTextCursorShouldBeLastSymbolInTagName()
    {
        // Arrange.
        var textCursor = new TextCursor("<div ");
        var tagNameFromTextCursor = new NameOfTagFromTextCursor(textCursor);
        
        // Act.
        tagNameFromTextCursor.Value();

        // Assert.
        Assert.That(textCursor.Current(), Is.EqualTo('v'));
    }

    [Test]
    public void WhenValue_AndTagClosedWithoutAttributes_ThenShouldCurrentBeLastSymbolInTagName()
    {
        // Arrange.
        var textCursor = new TextCursor("<div>");
        var tagNameFromTextCursor = new NameOfTagFromTextCursor(textCursor);
        
        // Act.
        tagNameFromTextCursor.Value();

        // Assert.
        Assert.That(textCursor.Current(), Is.EqualTo('v'));
    }
}