using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Security.Claims;
using Week5CaseStudy.Data;
using Week5CaseStudy.Models;

namespace Week5CaseStudy.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id, int page = 1, int pageSize = 2)
        {
            List<Category> categories = _context.Categories.ToList();
            ViewData["Categories"] = categories;

            Category category = _context.Categories.Find(id);

            PagedList<Post> model = new PagedList<Post>(_context.Posts
                .Include(p => p.User)
                .Include(p => p.Category)
                .Where(p => (p.Category_Id == category.Id && p.State == "Live"))
                .OrderByDescending(p => p.CreatedDate)  // İsteğe bağlı: Tarihe göre azalan sıralama
                    , page, pageSize);
            return View(model);
        }

    }
}
