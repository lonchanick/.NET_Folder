using Microsoft.Extensions.Primitives;
using System.Text;

namespace CSharp_11_Book;

public  static class ExtensionMethods
{
    public static StringBuilder sb = new();
    public static string ToString(this IEnumerable<Book> serie, string prefix)
    {
        foreach (var b in serie)
            sb.Append(prefix).AppendLine(b.ToString());

        return sb.ToString();
    }
}
