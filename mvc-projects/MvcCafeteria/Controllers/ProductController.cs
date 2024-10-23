using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Cafeteria.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public string Welcome(string name, int ID = 4)
    {
        return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
    }
}
