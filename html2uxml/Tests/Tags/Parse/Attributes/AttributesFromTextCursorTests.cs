using html2uxmlSharpDev.source.InternalTextCursor;
using htmlDocument.Source;
using NUnit.Framework;

namespace html2uxmlSharpDev.InternalTextCursor;

public class AttributesFromTextCursorTests
{
    [Test]
    public void WhenValue_AndCursorOnCloseTag_ThenShouldEmpty()
    {
        // Arrange.
        var textCursor = new AttributesFromTextCursor(new TextCursor(">"));

        // Act.
        var attributes = textCursor.Value().Value;

        // Assert.
        Assert.That(attributes.Count(), Is.EqualTo(0));
    }

    [Test]
    public void WhenValue_AndCursorOnCloseTag_ThenShouldNotIterate()
    {
        // Arrange.
        var textCursor = new TextCursor("> ");
        var targetTextCursor = new AttributesFromTextCursor(textCursor);

        // Act.
        _ = targetTextCursor.Value().Value;

        // Assert.
        Assert.That(textCursor.Current().ToString(), Is.EqualTo(">"));
    }

    [Test]
    public void WhenValue_AndContentHaveCloseTagSymbol_ThenShouldIterateWhileNotCloseBracketSymbol()
    {
        // Arrange.
        var textCursor = new TextCursor(" href=\"css/common.css\" />");
        var targetTextCursor = new AttributesFromTextCursor(textCursor);

        // Act.
        _ = targetTextCursor.Value().Value;

        // Assert.
        Assert.That(textCursor.Current().ToString(), Is.EqualTo(">"));
    }
}