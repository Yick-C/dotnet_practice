﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
