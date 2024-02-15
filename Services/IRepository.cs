using Microsoft.EntityFrameworkCore;
using Week5CaseStudy.Models;

namespace Week5CaseStudy.Services
{
    public interface IRepository
    {
        public List<Post> GetModel1Data();

        public List<Category> GetModel2Data();
    }
}
