using html2uxmlSharpDev.source.htmlDocument.Source;
using NUnit.Framework;

namespace html2uxmlSharpDev.SelfClosing;

public class SelfClosingTagsTests
{
    [Test]
    [TestCase("link", true)]
    [TestCase("img", true)]
    [TestCase("input", true)]
    [TestCase("br", true)]
    [TestCase("div", false)]
    public void WhenIsTagSelfClosing_AndPassTag_ThenShouldReturnExceptedResult(string tag, bool excepted)
    {
        // Arrange.
        var selfClosingTags = new SelfClosingTags();

        // Act.
        var isTagSelfClosing = selfClosingTags.IsTagSelfClosing(tag);

        // Assert.
        Assert.That(excepted, Is.EqualTo(isTagSelfClosing));
    }
}