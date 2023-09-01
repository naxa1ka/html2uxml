using html2uxmlSharpDev.source.InternalTextCursor;
using htmlDocument.Source;
using NUnit.Framework;

namespace html2uxmlSharpDev.InternalTextCursor;

public class ContentOfTagFromTextCursorTests
{
    [Test]
    public void WhenValue_AndCursorOnOpenTagBracketSymbol_AndContentDoesntExists_ThenShouldBeEmpty()
    {
        // Arrange.
        var textCursor = new TextCursor("></div>");
        var targetTextCursor = new ContentOfTagFromTextCursor(textCursor);

        // Act.
        var value = targetTextCursor.Value();

        // Assert.
        Assert.That(value, Is.EqualTo(string.Empty));
    }
    
    [Test]
    public void WhenValue_AndCursorOnCloseTagBracketSymbol_AndContentDoesntExists_ThenCursorShouldNotIterate()
    {
        // Arrange.
        var textCursor = new TextCursor("></d");
        var targetTextCursor = new ContentOfTagFromTextCursor(textCursor);

        // Act.
        var value = targetTextCursor.Value();

        // Assert.
        Assert.That(textCursor.Current(), Is.EqualTo('>'));
    }
    
    [Test]
    public void WhenValue_AndExistsContent_ThenShouldGetItBeforeCloseTagBracketSymbol()
    {
        // Arrange.
        var textCursor = new TextCursor("> hello </d"); 
        var targetTextCursor = new ContentOfTagFromTextCursor(textCursor);

        // Act.
        var value = targetTextCursor.Value();

        // Assert.
        Assert.That(value, Is.EqualTo(" hello "));
    }
    
    [Test]
    public void WhenValue_AndExistContent_ThenCursorShouldBeOnLastSymbolOnContent()
    {
        // Arrange.
        var textCursor = new TextCursor(">hello</d"); 
        var targetTextCursor = new ContentOfTagFromTextCursor(textCursor);

        // Act.
        _ = targetTextCursor.Value();

        // Assert.
        Assert.That(textCursor.Current(), Is.EqualTo('o'));
    }
}