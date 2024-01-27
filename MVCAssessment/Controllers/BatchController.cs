using Microsoft.AspNetCore.Mvc;
using MVCAssessment.Models;

namespace MVCAssessment.Controllers
{
    public class BatchController : Controller
    {
        static List<Student> list = new List<Student>();
        public BatchController()
        {
        }
        [HttpPost]
        public JsonResult UniqueIDValue(Student stu)
        {
            return Json(!list.Any(x => x.Id == stu.Id));
        }
        public IActionResult Index()
        {
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student stu)
        {
            if (ModelState.IsValid)
            {
                list.Add(stu);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.msg = "Please provide an id";
                return View();
            }
            else
            {
                var student = list.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    ViewBag.msg = "No record found for this id";
                    return View();
                }
                else
                {
                    return View(student);
                }
            }

        }
        [HttpPost]
        public IActionResult Edit(Student student, int id)
        {
            var temp = list.Where(x => x.Id == id).FirstOrDefault();
            if (temp != null)
            {
                foreach (Student stu in list)
                {
                    if (stu.Id == temp.Id)
                    {
                        stu.Name = student.Name;
                        stu.DateOfBirth = student.DateOfBirth;
                        stu.Address = student.Address;
                        stu.Batch=student.Batch;
                        break;
                       
                    }

                }
            }
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                ViewBag.msg = "Please provide an id";
                return View();
            }
            else
            {
                var student = list.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    ViewBag.msg = "No record found for this id";
                    return View();
                }
                else
                {
                    return View(student);
                }
            }

        }
        [HttpPost]
        public IActionResult Delete(Student student, int id)
        {
            var temp = list.Where((x) => x.Id == id).FirstOrDefault();
            if (temp != null)
            {
                list.Remove(temp);


            }
            return RedirectToAction("Index");
        }
        public IActionResult Display(int? id)
        {
            if (id == null)
            {
                ViewBag.msg = "Please provide an id";
                return View();
            }
            else
            {
                var student = list.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    ViewBag.msg = "No record found for this id";
                    return View();
                }
                else
                {
                    return View(student);
                }
            }

        }

    }
}
