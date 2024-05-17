using CRUDusingADOStudent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusingADOStudent.Controllers
{
    public class StudentController : Controller
    {
        StudentDAL stddal;
        private readonly IConfiguration configuration;
        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            stddal=new StudentDAL(this.configuration);
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var model = stddal.GetStudents();
            return View(model);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var std = stddal.GetStudentById(id);
            return View(std);
        }

        // GET: StudentController/Create
        public ActionResult Create()//add std page
        {
            
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student std)
        {
            try
            {
                int result = stddal.AddStudent(std);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }

        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)//edit page
        {
            var std=stddal.GetStudentById(id);
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student std)
        {
            try
            {

                int result = stddal.EditStudent(std);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }

            }
            catch(Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();

            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var std = stddal.GetStudentById(id);
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = stddal.DeleteStudent(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }

        }
    }
}
