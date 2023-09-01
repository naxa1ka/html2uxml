using html2uxmlSharpDev.source.InternalTextCursor;
using htmlDocument.Source;
using NUnit.Framework;

namespace html2uxmlSharpDev.InternalTextCursor;

public class ChildrenTagsFromTextCursorTests
{
    [Test]
    public void WhenValue_AndCursorInChildTags_ThenShouldReturnChildren()
    {
        // Arrange.
        const string childTag = "<div class=\"ic\"></div>";
        const string content = "<div>" +
                               $"   {childTag}" +
                               "</div>";
        var textCursor = new TextCursor(content);
        new CloseTagCommand(textCursor).Execute();
        var childrenTagsFromTextCursor = new ChildrenTagsFromTextCursor(textCursor);

        // Act.
        var tags = childrenTagsFromTextCursor.Value();

        // Assert.
        Assert.That(tags.Single().AsString(), Is.EqualTo(childTag));
    }

    [Test]
    public void WhenValue_AndCursorInChildTags_ThenShouldCurrentReturnOpenTag()
    {
        // Arrange.
        const string childTag = "<div class=\"ic\"></div>";
        const string content = "<div>" +
                               $"   {childTag}" +
                               "</div>";
        var textCursor = new TextCursor(content);
        new CloseTagCommand(textCursor).Execute();
        var childrenTagsFromTextCursor = new ChildrenTagsFromTextCursor(textCursor);

        // Act.
        var tags = childrenTagsFromTextCursor.Value();

        // Assert.
        Assert.That(textCursor.Current(), Is.EqualTo('<'));
        Assert.That(textCursor.Next(), Is.EqualTo('/'));
    }

    [Test]
    public void WhenValue_AndCursorInChildTags_AndHaveTwoChild_ThenShouldReturnTwoChild()
    {
        // Arrange.
        const string firstTag = "<div class=\"ic\"></div>";
        const string secondTag = "<div class=\"marked\"></div>";
        const string content = "<div>" +
                               $"   {firstTag}" +
                               $"   {secondTag}" +
                               "</div>";
        var textCursor = new TextCursor(content);
        new CloseTagCommand(textCursor).Execute();
        var childrenTagsFromTextCursor = new ChildrenTagsFromTextCursor(textCursor);

        // Act.
        var tags = childrenTagsFromTextCursor.Value().ToList();

        // Assert.
        Assert.That(tags[0].AsString(), Is.EqualTo(firstTag));
        Assert.That(tags[1].AsString(), Is.EqualTo(secondTag));
    }

    [Test]
    public void WhenValue_AndAndCursorInChildTag_AndChildrenHaveOwnChildren_ThenShouldReturnTagWithChildren()
    {
        // Arrange.
        const string innerChildrenTag = "<div class=\"ic ic-sm ic-rocket-fill\"></div>";
        const string content = "<div class=\"btn-group mx-md\">"
                               + "  <div class=\"btn btn-square bg-black\">"
                               + innerChildrenTag
                               + "  </div>"
                               + "</div>";
        var textCursor = new TextCursor(content);
        new CloseTagCommand(textCursor).Execute();
        var childrenTagsFromTextCursor = new ChildrenTagsFromTextCursor(textCursor);
        
        // Act.
        var tags = childrenTagsFromTextCursor.Value();
        
        // Assert.
        Assert.That(tags.Single().Children.Single().AsString(), Is.EqualTo(innerChildrenTag));
    }
}