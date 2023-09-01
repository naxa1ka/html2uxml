using htmlDocument.Source;
using NUnit.Framework;

namespace html2uxmlSharpDev;

public class ContentOfTextCursorTests
{
    [Test]
    public void WhenContentNext_ThenShouldReturnAllContentWithoutCurrent()
    {
        // Arrange.
        const string exceptedContent = "ello";
        var textCursor = new TextCursor($"h{exceptedContent}");
        var contentOfTextCursor = new ContentOfTextCursor(textCursor);
        
        // Act.
        var content = contentOfTextCursor.ContentNext();

        // Assert.
        Assert.That(content, Is.EqualTo(exceptedContent));
    }
    
    [Test]
    public void WhenContentPrev_AndCursorOnFirstSymbol_ThenShouldReturnEmpty()
    {
        // Arrange.
        var textCursor = new TextCursor("hello");
        var contentOfTextCursor = new ContentOfTextCursor(textCursor);
        
        // Act.
        var content = contentOfTextCursor.ContentPrev();

        // Assert.
        Assert.That(content, Is.EqualTo(string.Empty));
    }
    
    [Test]
    public void WhenContentPrevWithCurrent_AndCursorOnFirstSymbol_ThenShouldReturnFirstSymbol()
    {
        // Arrange.
        const string exceptedContent = "h";
        var textCursor = new TextCursor($"{exceptedContent}ello");
        var contentOfTextCursor = new ContentOfTextCursor(textCursor);
        
        // Act.
        var content = contentOfTextCursor.ContentPrevWithCurrentSymbol();

        // Assert.
        Assert.That(content, Is.EqualTo(exceptedContent));
    }

    [Test]
    public void WhenContentPrev_AndCursorOnLastSymbol_ThenShouldReturnContentWithoutCurrent()
    {
        // Arrange.
        const string exceptedContent = "hell";
        var textCursor = new TextCursor($"{exceptedContent}o");
        while (textCursor.CanIterateNext()) 
            textCursor.IterateNext();
        var contentOfTextCursor = new ContentOfTextCursor(textCursor);
        
        // Act.
        var content = contentOfTextCursor.ContentPrev();

        // Assert.
        Assert.That(content, Is.EqualTo(exceptedContent));
    }
    
    [Test]
    public void WhenContentPrevWithCurrent_AndCursorOnLastSymbol_ThenShouldReturnAllContent()
    {
        // Arrange.
        const string exceptedContent = "hello";
        var textCursor = new TextCursor(exceptedContent);
        while (textCursor.CanIterateNext()) 
            textCursor.IterateNext();
        var contentOfTextCursor = new ContentOfTextCursor(textCursor);
        
        // Act.
        var content = contentOfTextCursor.ContentPrevWithCurrentSymbol();

        // Assert.
        Assert.That(content, Is.EqualTo(exceptedContent));
    }

    
    [Test]
    public void WhenContentNextWithCurrent_ThenShouldReturnAllContentWithCurrent()
    {
        // Arrange.
        const string exceptedContent = "hello";
        var textCursor = new TextCursor(exceptedContent);
        var contentOfTextCursor = new ContentOfTextCursor(textCursor);
        
        // Act.
        var content = contentOfTextCursor.ContentNextWithCurrentSymbol();

        // Assert.
        Assert.That(content, Is.EqualTo(exceptedContent));
    }
}