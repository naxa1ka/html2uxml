using html2uxml.Source.String;
using NUnit.Framework;

namespace html2uxmlSharpDev.Extensions;

public class StringExtensionsTests
{
    [Test]
    [TestCase("hello", "olleh")]
    [TestCase("h", "h")]
    [TestCase("just", "tsuj")]
    [TestCase("he", "eh")]
    public void WhenReverse_ThenShouldReturnReversedString(string source, string excepted)
    {
        // Act.
        var reverse = source.Reverse();
        
        // Assert.
        Assert.That(reverse, Is.EqualTo(excepted));
    }
}