using Microsoft.AspNetCore.Mvc;
using Week5CaseStudy.Models;
using Week5CaseStudy.Services;

namespace Week5CaseStudy.Controllers
{
    public class MyViewModelController : Controller
    {
        private readonly IRepository _repository;

        public MyViewModelController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Create()
        {
            var model1List = _repository.GetModel1Data();
            var model2List = _repository.GetModel2Data();

            var viewModel = new MyViewModel
            {
                PostList = model1List,
                CategoryList = model2List,
                // Diğer modellerin özellikleri
            };

            return View(viewModel);
        }
    }
}
