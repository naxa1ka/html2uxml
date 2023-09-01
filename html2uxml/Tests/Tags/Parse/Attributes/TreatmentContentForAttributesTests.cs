using html2uxmlSharpDev.source.InternalTextCursor;
using NUnit.Framework;

namespace html2uxmlSharpDev.InternalTextCursor;

public class TreatmentContentForAttributesTests
{
    [Test]
    public void WhenValue_AndContentHaveOnlySpaces_ThenShouldReturnEmpty()
    {
        // Arrange.
        var treatmentContentForAttributes = new TreatmentContentForAttributes("    ");
        
        // Act.
        var value = treatmentContentForAttributes.Value();

        // Assert.
        Assert.That(value, Is.EqualTo(string.Empty));
    }

    [Test]
    public void WhenValue_AndLastSymbolCloseTag_ThenShouldReturnContentWithoutCloseTag()
    {
        // Arrange.
        const string exceptedContent = "some";
        var treatmentContentForAttributes = new TreatmentContentForAttributes($"{exceptedContent}\\");
        
        // Act.
        var value = treatmentContentForAttributes.Value();

        // Assert.
        Assert.That(value, Is.EqualTo(exceptedContent));
    }
}