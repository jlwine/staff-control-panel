using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using staff_control_panel.Controllers.Data;
using staff_control_panel.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static staff_control_panel.Models.NavigationProperty;

namespace staff_control_panel.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;

            if (_db.Posts.Count() == 0)
            {
                Post director = new Post { Name = "Директор" };
                Post lead = new Post { Name = "Руководитель подразделения" };
                Post controller = new Post { Name = "Контролер" };
                Post worker = new Post { Name = "Рабочий" };

                _db.Posts.AddRange(director, lead, controller, worker);
                _db.SaveChanges();
            }
        }
        [HttpGet]
        public ActionResult Index(int? post, string subunit)
        {
            IQueryable<Employee> employees = _db.Employees.Include(p => p.Post);
            if (post != null && post != 0)
            {
                employees = employees.Where(p => p.PostId == post);
            }
            if (!String.IsNullOrEmpty(subunit))
            {
                employees = employees.Where(p => p.subunit.Contains(subunit));
            }
            List<Post> posts = _db.Posts.ToList();

            EmployeeListViewModel viewmodel = new EmployeeListViewModel
            {
                Employees = employees.ToList(),
                Posts = new SelectList(posts, "Id", "Name")
                
            };
            return View(viewmodel);
        }
        
        //[HttpGet]
        //public IActionResult Index(int? jobSort, string subunitSort)
        //{
            
        //}

        public IActionResult Index()
        {
            IEnumerable<Employee> objEmployeeList = _db.Employees;
            return View(objEmployeeList);
        }
        //GET
        public IActionResult AddDirector()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDirector(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                await _db.SaveChangesAsync();
                TempData["success"] = "Сотрудник успешно добавлен";
                return RedirectToAction("Index");
            }
            return View();
        }
        //GET
        public IActionResult AddLeader()
        {
            return View();
        }
        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddLeader(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Сотрудник успешно добавлен";
                return RedirectToAction("Index");
            }
            return View();
        }
        //GET
        public IActionResult AddController()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddController(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Сотрудник успешно добавлен";
                return RedirectToAction("Index");
            }
            return View();
        }
        //GET
        public IActionResult AddWorker()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWorker(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Сотрудник успешно добавлен";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult ChoosingAddPost()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee obj)
        {
            if(ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Сотрудник успешно добавлен";
                return RedirectToAction("Index");
            }
            return View();
        }
        //Edit director
        public IActionResult EditDirector(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var EmployeeFromDb = _db.Employees.Find(Id);

            if(EmployeeFromDb == null)
            {
                return NotFound();
            }
            return View(EmployeeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDirector(Employee obj)
        {
            if(ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Данные сотрудника успешно изменены";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Edit lead
        public IActionResult EditLead(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var EmployeeFromDb = _db.Employees.Find(Id);

            if (EmployeeFromDb == null)
            {
                return NotFound();
            }
            return View(EmployeeFromDb);
        }

        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLead(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Данные сотрудника успешно изменены";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Edit controller
        public IActionResult EditController(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var EmployeeFromDb = _db.Employees.Find(Id);

            if (EmployeeFromDb == null)
            {
                return NotFound();
            }
            return View(EmployeeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditController(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Данные сотрудника успешно изменены";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Edit worker
        public IActionResult EditWorker(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var EmployeeFromDb = _db.Employees.Find(Id);

            if (EmployeeFromDb == null)
            {
                return NotFound();
            }
            return View(EmployeeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditWorker(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Данные сотрудника успешно изменены";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //UpgradeStaff
        public IActionResult UpgradeStaff(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var EmployeeFromDb = _db.Employees.Find(Id);

            if (EmployeeFromDb == null)
            {
                return NotFound();
            }
            return View(EmployeeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpgradeStaff(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Данные сотрудника успешно изменены";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Employees.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
