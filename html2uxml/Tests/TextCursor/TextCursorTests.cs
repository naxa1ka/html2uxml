using System.Text;
using htmlDocument.Source;
using NUnit.Framework;

// ReSharper disable ObjectCreationAsStatement
#pragma warning disable CS8625

namespace html2uxmlSharpDev;

public class TextCursorTests
{
    [Test]
    public void WhenCanIterateNext_AndContentLengthGreaterOne_ThenShouldReturnTrue()
    {
        // Arrange.
        var stringIterator = new TextCursor("he");

        // Act.
        var canIterateNext = stringIterator.CanIterateNext();

        // Assert.
        Assert.That(canIterateNext, Is.EqualTo(true));
    }

    [Test]
    public void WhenCanIteratePrev_AndIterateNext_ThenShouldReturnTrue()
    {
        // Arrange.
        var stringIterator = new TextCursor("he");
        stringIterator.IterateNext();

        // Act.
        var canIteratePrev = stringIterator.CanIteratePrev();

        // Assert.
        Assert.That(canIteratePrev, Is.EqualTo(true));
    }

    [Test]
    public void WhenCanIteratePrev_AndLengthContentEqualOne_ThenShouldReturnFalse()
    {
        // Arrange.
        var stringIterator = new TextCursor(" ");

        // Act.
        var canIterateNext = stringIterator.CanIteratePrev();

        // Assert.
        Assert.That(canIterateNext, Is.EqualTo(false));
    }

    [Test]
    public void WhenCanIterateNext_AndLengthContentEqualTwo_AndIterateNext_ThenShouldReturnFalse()
    {
        // Arrange.
        var stringIterator = new TextCursor("12");
        stringIterator.IterateNext();

        // Act.
        var canIterateNext = stringIterator.CanIterateNext();
        
        // Assert.
        Assert.Multiple(() =>
        {
            Assert.That(stringIterator.Current().ToString(), Is.EqualTo("2"));
            Assert.That(canIterateNext, Is.EqualTo(false));
        });
    }

    [Test]
    public void WhenCanIterateNext_AndLengthContentEqualOne_ThenShouldReturnFalse()
    {
        // Arrange.
        var stringIterator = new TextCursor(" ");

        // Act.
        var canIterateNext = stringIterator.CanIterateNext();

        // Assert.
        Assert.That(canIterateNext, Is.EqualTo(false));
    }

    [Test]
    public void WhenPrev_ThenCurrentShouldNotBeChanged()
    {
        // Arrange.
        const char currentSymbol = 'e';
        var stringIterator = new TextCursor($"h{currentSymbol}");
        stringIterator.IterateNext();

        // Act.
        var _ = stringIterator.Prev();

        // Assert.
        Assert.That(stringIterator.Current(), Is.EqualTo(currentSymbol));
    }

    [Test]
    public void WhenNext_ThenCurrentShouldNotBeChanged()
    {
        // Arrange.
        const char currentSymbol = 'h';
        var stringIterator = new TextCursor($"{currentSymbol}e");

        // Act.
        var _ = stringIterator.Next();

        // Assert.
        Assert.That(stringIterator.Current(), Is.EqualTo(currentSymbol));
    }

    [Test]
    public void WhenNext_ThenSymbolShouldBeNextSymbolFromCurrentIndex()
    {
        // Arrange.
        const char nextSymbol = 'e';
        var stringIterator = new TextCursor($"h{nextSymbol}");

        // Act.
        var next = stringIterator.Next();

        // Assert.
        Assert.That(next, Is.EqualTo(nextSymbol));
    }

    [Test]
    public void WhenPrev_ThenSymbolShouldBePrevSymbolFromCurrentIndex()
    {
        // Arrange.
        const char firstCharacter = 'h';
        var stringIterator = new TextCursor($"{firstCharacter}e");
        stringIterator.IterateNext();

        // Act.
        var prev = stringIterator.Prev();

        // Assert.
        Assert.That(prev, Is.EqualTo(firstCharacter));
    }

    [Test]
    public void WhenIteratePrev_ThenCurrentShouldBePrevSymbolFromCurrentIndex()
    {
        // Arrange.
        const char firstCharacter = 'h';
        var stringIterator = new TextCursor($"{firstCharacter}e");
        stringIterator.IterateNext();

        // Act.
        stringIterator.IteratePrev();

        // Assert.
        var current = stringIterator.Current();
        Assert.That(current, Is.EqualTo(firstCharacter));
    }

    [Test]
    public void WhenIterateNext_ThenCurrentShouldBeNextSymbolFromStartString()
    {
        // Arrange.
        const char nextSymbol = 'e';
        var stringIterator = new TextCursor($"h{nextSymbol}");

        // Act.
        stringIterator.IterateNext();

        // Assert.
        var current = stringIterator.Current();
        Assert.That(current, Is.EqualTo(nextSymbol));
    }

    [Test]
    public void WhenConstruct_AndPassEmptyContent_ThenShouldThrowArgumentOutOfRangeException()
    {
        // Act.
        TestDelegate create = () => new TextCursor(string.Empty);

        // Assert.
        Assert.Throws<ArgumentOutOfRangeException>(create);
    }


    [Test]
    public void WhenConstruct_AndPassNull_ThenShouldThrowArgumentNullException()
    {
        // Act.
        TestDelegate create = () => new TextCursor(content: null);

        // Assert.
        Assert.Throws<ArgumentNullException>(create);
    }

    [Test]
    public void WhenCurrent_ThenShouldBeEqualFirstSymbol()
    {
        // Arrange.
        const char character = '1';
        var stringIterator = new TextCursor(character.ToString());

        // Act.
        var current = stringIterator.Current();

        // Assert.
        Assert.That(current, Is.EqualTo(character));
    }

    [Test]
    public void WhenConstruct_AndPassStringIteratorWithCurrentIndexOne_ThenShouldSubstringContentStartFromOne()
    {
        // Arrange.
        const string subContent = "ello world";
        var stringIterator = new TextCursor($"h{subContent}");
        stringIterator.IterateNext();

        // Act.
        var newStringIterator = new TextCursor(stringIterator);

        // Assert.
        var sb = new StringBuilder();
        while (newStringIterator.CanIterateNext())
        {
            sb.Append(newStringIterator.Current());
            newStringIterator.IterateNext();
        }

        sb.Append(newStringIterator.Current());

        Assert.That(sb.ToString(), Is.EqualTo(subContent));
    }
}