using html2uxml.Source.Tags.Core;
using html2uxmlSharpDev.source.htmlDocument.Source;
using NUnit.Framework;

namespace html2uxmlSharpDev;

public class Tests
{
    [Test]
    public void Whenact_Andarrange_Thenassert()
    {
        // Arrange.
        var content = File.ReadAllText("../../../tests/DocumentWithChild.html");

        var tagName = new HtmlDocument(content);
        var asString = tagName.AsString();
        int i = 0;
        // Act.

        // Assert.
    }

    [Test]
    public void Test3()
    {
        var content = File.ReadAllText("../../../tests/LinkTagAttributes.txt");
        var attributes = new Attributes(content);
        foreach (var attribute in attributes.Value)
        {
            Console.WriteLine(attribute.AsString());
        }
    }
}