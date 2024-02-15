using Week5CaseStudy.Data;
using Week5CaseStudy.Services;

namespace Week5CaseStudy.Models
{
    public class MyRepository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public MyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Post> GetModel1Data()
        {
            // Model1 verilerini veritabanından çek
            return _context.Posts.ToList();
        }

        public List<Category> GetModel2Data()
        {
            // Model2 verilerini veritabanından çek
            return _context.Categories.ToList();
        }        
        
        public List<Hashtag> GetModel3Data()
        {
            // Model3 verilerini veritabanından çek
            return _context.Hashtags.ToList();
        }
    }
}
