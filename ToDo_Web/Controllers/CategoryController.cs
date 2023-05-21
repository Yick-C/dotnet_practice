using Microsoft.AspNetCore.Mvc;
using ToDo_Web.Data;
using ToDo_Web.Models;

namespace ToDo_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        // GET ACTION METHOD
        public IActionResult Create()
        {
            return View();
        }

        // POST ACTION METHOD
        // Validation to generate a key and prevent forgery on post request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot be the same as the Name");
            }
            // Checks null values
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET ACTION METHOD
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id); // Get the primary key
            // var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            // var categoryFromDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id); // throws exception if more than one item is given

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        // POST ACTION METHOD
        // Validation to generate a key and prevent forgery on post request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot be the same as the Name");
            }
            // Checks null values
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
