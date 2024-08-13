using CRUDModels;
using CRUDService;
using CRUDService.Interface;
using Microsoft.AspNetCore.Mvc;


namespace CRUD_IN_MVC.Controllers
{
    public class CreateController : Controller
    {
        private readonly ICreateService _crudservice;
        public CreateController(ICreateService crudservice)
        {
            _crudservice = crudservice;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _crudservice.GetAllDetails();
            return View(result);
        }


        public IActionResult Create()
        {
           return View();
        }


        [HttpPost]
        public IActionResult CreateData(CreateViewModel createViewModel)
        {
          var result= _crudservice.CreateAllDetails(createViewModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult DeactivateData(int? id)
        {
            var result = _crudservice.GetDataBasedOnId(id).Result;
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeactivateDataOfStudent(int? id)
        {
            if (id == null)
            {
                return BadRequest("ID cannot be null.");
            }

            var result = _crudservice.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var result = _crudservice.GetDataBasedOnId(id).Result;
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateRecordOfStudent(CreateViewModel createViewModel)
        {
            var result = _crudservice.UpdateData(createViewModel);
            return RedirectToAction(nameof(Index));
        }



    }
}
