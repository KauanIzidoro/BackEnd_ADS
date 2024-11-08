using System.ComponentModel.DataAnnotations;

namespace Cafeteria.Models;

public class ProductDTO
{
    public required string Name {get;set;}
    public required int Quantity {get;set;}
    public string Category {get;set;}
    public required decimal Price {get;set;}

}
