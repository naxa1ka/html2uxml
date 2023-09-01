using html2uxmlSharpDev.source.htmlDocument.Source;
using NUnit.Framework;

namespace html2uxmlSharpDev.Attribute;

public class AttributesTest
{
    [Test]
    public void WhenValue_AndContentEmpty_ThenAttributesLengthShouldBeZero()
    {
        // Arrange.
        var attributes = new Attributes("");

        // Act.
        var value = attributes.Value;

        // Assert.
        Assert.That(value.Count(), Is.EqualTo(0));
    }

    [Test]
    public void WhenValue_AndExistsSpaceBetweenNameAndAssignmentValueSymbol_ThenAttributeShouldHaveNameWithoutSpace()
    {
        // Arrange.
        const string attributeName = "rel";
        var attributes = new Attributes($"{attributeName} =\"content\"");

        // Act.
        var attribute = attributes.Value.First();

        // Assert.
        Assert.That(attribute.Name, Is.EqualTo(attributeName));
    }

    [Test]
    public void WhenValue_AndExistsSpaceBetweenAssignmentValueSymbolAndOpenValueSymbol_ThenShouldCorrectParse()
    {
        // Arrange.
        const string name = "rel";
        const string value = "content";
        var attributes = new Attributes($"{name}= \"{value}\"");

        // Act.
        var attribute = attributes.Value.First();

        // Assert.
        Assert.Multiple(() =>
        {
            Assert.That(attribute.Name, Is.EqualTo(name));
            Assert.That(attribute.Value, Is.EqualTo(value));
        });
    }

    [Test]
    public void WhenValue_AndAttributeHaveCloseTagSymbol_ThenAttributeShouldHaveCorrectValue()
    {
        // Arrange.
        const string name = "href";
        const string value = "css/common.css";
        var attributes = new Attributes($"{name}=\"{value}\"");

        // Act.
        var attribute = attributes.Value.First();

        // Assert.
        Assert.Multiple(() =>
        {
            Assert.That(attribute.Name, Is.EqualTo(name));
            Assert.That(attribute.Value, Is.EqualTo(value));
        });
    }
    
    
    [Test]
    public void WhenValue_AndContentHaveTwoAttributes_ThenShouldCorrectParse()
    {
        // Arrange.
        const string firstNameOfAttribute = "rel";
        const string firstValueOfAttribute = "stylesheet";
        const string secondNameOfAttribute = "href";
        const string secondValueOfAttribute = "css";
        
        var attributes = new Attributes(
            $"{firstNameOfAttribute}=\"{firstValueOfAttribute}\" " +
            $"{secondNameOfAttribute}=\"{secondValueOfAttribute}\""
        );

        // Act.
        var value = attributes.Value.ToArray();
        var firstAttribute = value[0];
        var secondAttribute = value[1];

        // Assert.
        Assert.Multiple(() =>
        {
            Assert.That(firstAttribute.Name, Is.EqualTo(firstNameOfAttribute));
            Assert.That(firstAttribute.Value, Is.EqualTo(firstValueOfAttribute));
            Assert.That(secondAttribute.Name, Is.EqualTo(secondNameOfAttribute));
            Assert.That(secondAttribute.Value, Is.EqualTo(secondValueOfAttribute));
        });
    }
}