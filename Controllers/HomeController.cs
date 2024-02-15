using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Week5CaseStudy.Data;
using Week5CaseStudy.Models;
using PagedList.Core;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;
using System.Security.Claims;
namespace Week5CaseStudy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index(int page = 1, int pageSize = 2)
        {
            //Categories dropdown u için lazım
            List<Category> categories = _context.Categories.ToList();
            ViewData["Categories"] = categories;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            PagedList<Post> model = new PagedList<Post>(_context.Posts
                    .Include(p => p.User)
                    .Include(p => p.Category)
                    .Where(p => p.State == "Live")
                    .OrderByDescending(p => p.CreatedDate)  // İsteğe bağlı: Tarihe göre azalan sıralama
                    , page, pageSize);
            return View(model);


            //try
            //{
            //    throw new NotImplementedException();
            //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //    PagedList<Post> model = new PagedList<Post>(_context.Posts.Include(p => p.User).Include(p => p.Category).Where(p => p.State == "Live"), page, pageSize);

            //    return View(model);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "Hata oluştu: {ErrorMessage}", ex.Message);
            //    // Diğer hata işleme kodları...
            //}

        }

    }
}
