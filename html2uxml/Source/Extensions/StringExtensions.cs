namespace html2uxml.Source.String;

public static class StringExtensions
{
    public static string Reverse(this string source)
    {
        var charArray = source.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}