using DataAccess.Repositories.BookRepository;
using DataAccess.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Mvc;
using Portfolio1.Models;
using System.Diagnostics;

namespace Movies.Areas.Customer.Controllers;

[Area("Customer")]

public class HomeController : Controller
{
  private readonly IBookRepository _bookDB;
  private readonly ICategoryRepository _catDB;
  private readonly IWebHostEnvironment _WebHostEnv;
  public HomeController(IBookRepository db, ICategoryRepository catDb, IWebHostEnvironment WebHostEnv)
  {
    _bookDB = db;
    _catDB = catDb;
    _WebHostEnv = WebHostEnv;
  }

  // GET: Book
  public IActionResult Index()
  {
    List<Book> BookList = _bookDB.GetAll(includeProperties: "Category").ToList();
    return View(BookList);
  }
    
  public IActionResult Details(int? ProductIdShouldBeTheSameAsHere)
  {
    if (ProductIdShouldBeTheSameAsHere is null || ProductIdShouldBeTheSameAsHere == 0)
      return View("Home", "Index");

    Book? book = _bookDB.GetById(b => b.Id == ProductIdShouldBeTheSameAsHere, includeProperties: "Category");

    if(book is null)
      return View("Home", "Index");//por lo prponto retorna a este directorio si el book no existe

    return View(book);
  }

  public IActionResult Privacy()
  {
    return View();  
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
