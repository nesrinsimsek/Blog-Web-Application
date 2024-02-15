using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Week5CaseStudy.Data;
using Week5CaseStudy.Models;
using Week5CaseStudy.Services;
using PagedList.Core;
using System.Security.Claims;
namespace Week5CaseStudy.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository _repository;
        public PostController(ApplicationDbContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(int page = 1, int pageSize = 2)
        {
            List<Category> categories = _context.Categories.ToList();
            ViewData["Categories"] = categories;
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            PagedList<Post> model = new PagedList<Post>(_context.Posts
                .Include(p => p.User)
                .Include(p => p.Category)
                .Where(p => p.User_Id == userId)
                .OrderByDescending(p => p.CreatedDate)  // İsteğe bağlı: Tarihe göre azalan sıralama
                    , page, pageSize);

            return View(model);
        }

        public IActionResult PostDetails(int id)
        {
            List<Category> categories = _context.Categories.ToList();
            ViewData["Categories"] = categories;

            // Veritabanından ilgili post'u al
            Post post = _context.Posts.Find(id);

            if (post == null)
            {
                return NotFound(); // Post bulunamazsa 404 hatası döndür
            }

            return View(post);
        }
        public IActionResult Create()
        {
            List<Category> categories = _context.Categories.ToList();
            ViewData["Categories"] = categories;
            
            var model1List = _repository.GetModel1Data();
            var model2List = _repository.GetModel2Data();

            var myViewModel = new MyViewModel
            {
                PostList = model1List,
                CategoryList = model2List,
                // Diğer modellerin özellikleri
            };
          

            return View(myViewModel);
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            List<Category> categories = _context.Categories.ToList();
            ViewData["Categories"] = categories;

            _context.Posts.Add(post);
            _context.SaveChanges();
            return Redirect("/Home");
        }
    }
}
