using System.ComponentModel.DataAnnotations;

namespace Cafeteria.Models;

public class Product
{
    public int Id {get;set;}
    public required string Name {get;set;}
    public required int Quantity {get;set;}
    public string Category {get;set;}
    public required decimal Price {get;set;}

}
