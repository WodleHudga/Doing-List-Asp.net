using Doing_List.Data;
using Doing_List.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Doing_List.Controllers
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
        //GET list
        public IActionResult Create()
        {        
            return View();
        }
        //POST list
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Marks Created Successfully ";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET edit
        public IActionResult Edit(int? id)

        {
            if(id == null || id == 0)
            {
                return NotFound();

            }
            var CategoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            return View(CategoryFromDb);
        }
        //POST edit
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Marks Updated Successfully ";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET Delete
        public IActionResult Delete (int? id)

        {
            if (id == null || id == 0)
            {
                return NotFound();

            }
            var CategoryFromDb = _db.Categories.FirstOrDefault(c => c.Id == id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            return View(CategoryFromDb);
        }
        //POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST (int? id)
        {
           var obj = _db.Categories.FirstOrDefault(c => c.Id == id);
            if(obj == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Marks Deleted Successfully ";
            return RedirectToAction("Index");
            
        }
        
    }
}

