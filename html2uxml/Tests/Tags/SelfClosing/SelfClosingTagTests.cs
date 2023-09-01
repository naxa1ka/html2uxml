using html2uxmlSharpDev.source.htmlDocument.Source;
using htmlDocument.Source;
using NUnit.Framework;
using HAttribute = html2uxmlSharpDev.source.htmlDocument.Source.Attribute;

namespace html2uxmlSharpDev.SelfClosing;

public class SelfClosingTagTests
{
    [Test]
    public void WhenChildren_ThenShouldReturnEmpty()
    {
        // Arrange.
        var selfClosingTag = new SelfClosingTag("", new List<IAttribute>());

        // Act.
        var children = selfClosingTag.Children;

        // Assert.
        Assert.That(children.Count(), Is.EqualTo(0));
    }

    [Test]
    public void WhenName_ThenShouldReturnNameFromConstructor()
    {
        // Arrange.
        const string exceptedName = "name";
        var selfClosingTag = new SelfClosingTag($"{exceptedName}", new List<IAttribute>());

        // Act.
        var name = selfClosingTag.Name;

        // Assert.
        Assert.That(name, Is.EqualTo(exceptedName));
    }

    [Test]
    public void WhenContent_ThenShouldReturnEmpty()
    {
        // Arrange.
        var selfClosingTag = new SelfClosingTag("", new List<IAttribute>());

        // Act.
        var content = selfClosingTag.Content;

        // Assert.
        Assert.That(content, Is.EqualTo(string.Empty));
    }

    [Test]
    public void WhenAttributes_AndPassAttributesInConstructor_ThenShouldReturnAttributesFromConstructor()
    {
        // Arrange.
        var exceptedAttributes = new List<IAttribute> { new HAttribute("name", "value") };
        var selfClosingTag = new SelfClosingTag("", exceptedAttributes);

        // Act.
        var attributes = selfClosingTag.Attributes;

        // Assert.
        CollectionAssert.AreEqual(exceptedAttributes, attributes);
    }
}