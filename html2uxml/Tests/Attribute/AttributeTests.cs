using NUnit.Framework;
using HAttribute = html2uxmlSharpDev.source.htmlDocument.Source.Attribute;

namespace html2uxmlSharpDev.Attribute.Tests;

public class AttributeTests
{
    [Test]
    public void WhenValue_ThenShouldReturnValueFromConstructor()
    {
        // Arrange.
        const string valueAsString = "value";
        var attribute = new HAttribute("attribute", valueAsString);

        // Act.
        var value = attribute.Value;

        // Assert.
        Assert.That(value, Is.EqualTo(valueAsString));
    }
    
    [Test]
    public void WhenName_ThenShouldReturnNameFromConstructor()
    {
        // Arrange.
        const string nameAsString = "attribute";
        var attribute = new HAttribute(nameAsString,  "value");

        // Act.
        var name = attribute.Name;

        // Assert.
        Assert.That(name, Is.EqualTo(nameAsString));
    }
    
    [Test]
    public void WhenAsString_ThenShouldReturnNameEqualValue()
    {
        // Arrange.
        const string nameAsString = "attribute";
        const string valueAsString = "value";
        var attribute = new HAttribute(nameAsString,  valueAsString);

        // Act.
        var asString = attribute.AsString();

        // Assert.
        Assert.That(asString, Is.EqualTo($"{nameAsString}=\"{valueAsString}\""));
    }
}