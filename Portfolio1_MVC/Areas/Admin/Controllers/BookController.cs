using DataAccess.Repositories.BookRepository;
using DataAccess.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portfolio1.Models;
using Portfolio1.Models.ViewModels;

namespace Movies.Areas.Admin.Controllers;

[Area("Admin")]
public class BookController : Controller
{
    private readonly IBookRepository _bookDB;
    private readonly ICategoryRepository _catDB;
    private readonly IWebHostEnvironment _WebHostEnv;
    public BookController(IBookRepository db, ICategoryRepository catDb, IWebHostEnvironment WebHostEnv)
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

    // GET: Book/Details/5
    public IActionResult Details(int id)
    {
        if (id != null && id != 0)
        {
            var book = _bookDB.GetById(book => book.Id == id);
            return View(book);
        }

        return NotFound();
    }

    // GET: Book/Create
    public IActionResult Upsert(int? id)
    {
        if (id != null && id != 0)
        {
            //UPDATE
            //var book = _db.GetById(book => book.Id == id);
            //return View(book);
            return View(new BookVM
            {
                CategoryOptions = _catDB.GetAll()
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }),

                Book = _bookDB.GetById(book => book.Id == id)
            });
        }
        else
        {
            //CREATE
            return View(new BookVM
            {
                CategoryOptions = _catDB.GetAll()
                .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }),

                Book = new Book()
            });
        }

    }

    // POST: Book/Create
    //[ValidateAntiForgeryToken]
    [HttpPost]
    public IActionResult Upsert(BookVM obj, IFormFile? file)
    {

        //esto funciona en cordinacion con los data anotations
        //y checkea todas las restricciones anotadas
        if (!ModelState.IsValid)
        {
            obj.CategoryOptions = _catDB.GetAll()
            .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View(obj);
            //return View();  
        }

        if (obj.Book.Id == 0)
        {
            //EN ESTE CASO ES PARA CREAR UN NUEVO OBJECTO
            if (file != null)
            {
                string wwwroot = _WebHostEnv.WebRootPath;
                string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string bookPath = Path.Combine(wwwroot, @"Images\Book", fileName);

                using (FileStream fs = new(bookPath, FileMode.Create))
                {
                    file.CopyTo(fs);
                }

                obj.Book.ImageUrl = "/Images/Book/" + fileName;
            }

            _bookDB.Add(obj.Book);
            _bookDB.Save();

            TempData["success"] = "New book created!";

            return RedirectToAction("Index", "Book");
        }
        else
        {
            //EN ESTE CASO ES PARA ACTUALIZAR UN BOJETO

            /*si el objeto a actualiza no tiene imagen asociada el campo imageUrl sera null o empty*/
            string bookUrlNormalization =
                string.IsNullOrEmpty(obj.Book.ImageUrl) ? "/" : obj.Book.ImageUrl[1..];

            /*reemplazaa los forward slashes por backward slashes*/
            string bookUrl = bookUrlNormalization.Replace('/', '\\');

            /*esta pregunta ya no hace sentido ya que la linea 117 se asegura de que siempre tenga un forwardslash*/
            /*esto hay que corregirlo*/
            if (!string.IsNullOrEmpty(bookUrl))
            {
                //en caso de que exista una nueva imagen de actualizacion
                string wwwroot = _WebHostEnv.WebRootPath;
                string fullDirectory = Path.Combine(wwwroot, bookUrl);

                bool fileExist = System.IO.File.Exists(fullDirectory);
                if (fileExist)
                    System.IO.File.Delete(fullDirectory);

                string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string bookPath = Path.Combine(wwwroot, @"Images\Book", fileName);

                using (FileStream fs = new(bookPath, FileMode.Create))
                    file.CopyTo(fs);

                obj.Book.ImageUrl = "/Images/Book/" + fileName;

            }
            _bookDB.Update(obj.Book);
            TempData["success"] = "ES UNA ACTUALIZACION";
            return RedirectToAction("Index", "Book");
        }

    }

    public IActionResult Delete([FromRoute(Name = "id")] int bookId)
    {
        var toRemove = _bookDB.GetById(book => book.Id == bookId);

        if (toRemove != null)
            return View(toRemove);

        return NotFound();

    }



    #region API calls
    [HttpGet]
    public IActionResult GetAll()
    {
        List<Book> BookList = _bookDB.GetAll(includeProperties: "Category").ToList();
        return Json(new { data = BookList });
    }

    //[HttpDelete]
    public IActionResult Delete(int? id)
    {
        var productToBeDeleted = _bookDB.GetById(u => u.Id == id);
        if (productToBeDeleted == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }
        var oldImagePath =
                        Path.Combine(_WebHostEnv.WebRootPath,
                        productToBeDeleted.ImageUrl.TrimStart('\\'));

        if (System.IO.File.Exists(oldImagePath))
        {
            System.IO.File.Delete(oldImagePath);
        }

        _bookDB.Remove(productToBeDeleted);
        _bookDB.Save();

        return Json(new { success = true, message = "Delete Successful" });
    }



    #endregion


}
