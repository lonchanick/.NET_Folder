using System.Text;

namespace CSharp_11_Book;

/// <summary>
/// Indexers about
/// </summary>
public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; } = "Defaultu-desc";
    public DateTime PublishDate { get; set; }

    public override string ToString()
    {
        return Title.ToString();
    }

}
public class BookSerie
{

    public Dictionary<string, List<Book>> Books;

    public BookSerie() 
    { 
        Books = new()
        {
            ["First Collection"] = new()
        {
            new(){ISBN="ISBN-0001-XYZ", Title="Collection#1-Book1", PublishDate=new DateTime(1991,10,08)},
            new(){ISBN="ISBN-0001-XYZ", Title="Collection#1-Book2", PublishDate=new DateTime(1991,10,08)},
            new(){ISBN="ISBN-0001-XYZ", Title="Collection#1-Book3", PublishDate=new DateTime(1991,10,08)}
        },
            ["Second Collection"] = new()
        {
            new(){ISBN="ISBN-0001-XYZ", Title="Collection#2-Book1", PublishDate=new DateTime(1991,10,08)},
            new(){ISBN="ISBN-0001-XYZ", Title="Collection#2-Book2", PublishDate=new DateTime(1991,10,08)},
            new(){ISBN="ISBN-0001-XYZ", Title="Collection#2-Book3", PublishDate=new DateTime(1991,10,08)}
        },
            ["Third Collection"] = new()
        {
            new(){ISBN="ISBN-0001-XYZ", Title="Collection#3-Book1", PublishDate=new DateTime(1991,10,08)},
            new(){ISBN="ISBN-0001-XYZ", Title="Collection#3-Book2", PublishDate=new DateTime(1991,10,08)},
            new(){ISBN="ISBN-0001-XYZ", Title="Collection#3-Book3", PublishDate=new DateTime(1991,10,08)}
        },

        };
    }

    public int count() => (Books.Count());

    public List<Book> this[int idx]=> Books.Values.ElementAt(idx);

    //syntax to get an element associated to a key in a dictionary
    //dict["keyValue"] //this is how I ask for an element using its key associated
    public List<Book>  this[string idx] => Books[idx];

    public Book this[string idx, int bookidx] => Books[idx][bookidx];

    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (var c in Books)
        {
            sb.Append(c.Key);
            sb.Append(c.Value.ToString("\t"));
        }

        return sb.ToString();
    }

}
