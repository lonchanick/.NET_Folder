using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.Shared;

public class Category
{
    public Category()
    {
        Products = new HashSet<Product>();
    }

    public int CategoryId{get; set;}
    public string? CategoryName{get; set;}
    [Column(TypeName="ntext")]
    public string? Description {get; set;}
    public virtual IEnumerable<Product> Products {get; set;}
    
    
}