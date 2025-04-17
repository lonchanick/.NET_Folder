using DataAccess.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Mvc;
using Portfolio1.Models;

namespace Movies.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    protected readonly ICategoryRepository _db;
    public CategoryController(ICategoryRepository dbParam)
    {
        _db = dbParam;
    }

    // GET: CategoryController
    public IActionResult Index()
    {
        IEnumerable<Category> categories = _db.GetAll();
        return View(categories);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category obj)
    {
        //custom validatin - custom error message
        //esta validacion no esta hecha con data anotations 
        if (obj.Name == obj.DisplayOrder.ToString())
            ModelState.AddModelError("name", "Asi no mierda!");

        //esta validacion no esta hecha con data anotations 
        //global validation: si el primer campo esta vacio valida para todo el formulario
        if (obj.Name == "TEST")
            ModelState.AddModelError("", $"{obj.Name} is not a valid value!");

        //esto funciona en cordinacion con los data anotations
        //y checkea todas las restricciones anotadas
        if (!ModelState.IsValid)
            return View();

        _db.Add(obj);
        _db.Save();

        TempData["success"] = "New category created!";

        return RedirectToAction("Index", "Category");
    }

    //cuando no se define ningun metodo "post - patch - get - etc .."
    //por defecto se usa el metodo Get
    //[Route("Category/Index/Edit/{id}")]
    public IActionResult Edit(int? id)
    {
        if (id != null && id != 0)
        {
            var category = _db.GetById(cat => cat.Id == id);
            return View(category);
        }
        else
            return NotFound();
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        _db.Update(category);
        _db.Save();

        TempData["success"] = "Category edited!";

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        var toRemove = _db.GetById(cat => cat.Id == id);
        if (toRemove == null)
        {
            return NotFound();
        }
        return View(toRemove);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        var toRemove = _db.GetById(c => c.Id == id);
        if (toRemove != null)
        {
            _db.Remove(toRemove);
            _db.Save();

            TempData["success"] = "New category deleted!";

            return RedirectToAction("Index");
        }
        return NotFound();
    }


    public IActionResult Details(int? id)
    {
        return null;
    }


}
