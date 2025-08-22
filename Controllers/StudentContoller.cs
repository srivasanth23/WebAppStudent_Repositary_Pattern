//using Microsoft.AspNetCore.Mvc;
//using WebAppStudent_Repositary_Pattern.Repositories;
//using WebAppStudent_Repositary_Pattern.Repositories.Interfaces;

//namespace WebAppStudent_Repositary_Pattern.Controllers
//{
//    public class StudentContoller : Controller
//    {
//        private readonly IStudentRepository _studentRepository;

//        //Constructor injection for repository
//        public StudentContoller(IStudentRepository studentRepository) { 
//            _studentRepository = studentRepository;
//        }

//        // -------------------------------------------
//        // GET: /Student
//        // List all students
//        // -------------------------------------------
//        public async Task<IActionResult> Index()
//        {
//            var students = await _studentRepository.GetAllStudentsAsync();
//            return View(students);
//        }

//        // -------------------------------------------
//        // GET: /Student/Details/5
//        // Show details of a specific student
//        // -------------------------------------------
//        public async Task<IActionResult> Details(int id)
//        {
//            var student = await _studentRepository.GetStudentByIdAsync(id);
//            if (student == null)
//            {
//                return NotFound();
//            }
//            return View(student);
//        }

//        // -------------------------------------------
//        // GET: /Student/Create
//        // Show create form
//        // -------------------------------------------
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // -------------------------------------------
//        // POST: /Student/Create
//        // Add new student
//        // -------------------------------------------
//        [HttpPost] //Using HTTP POST method
//        [ValidateAntiForgeryToken] // Prevent CSRF attacks
//        public async Task<IActionResult> Create([Bind("Name,Email,Address")] Models.Students student)
//        {
//            if (ModelState.IsValid)
//            {
//                await _studentRepository.AddStudentAsync(student);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(student);
//        }


//        // -------------------------------------------
//        // GET: /Student/Edit/5
//        // Show edit form
//        // -------------------------------------------
//        public async Task<IActionResult> Edit(int id)
//        {
//            var student = await _studentRepository.GetStudentByIdAsync(id);
//            if (student == null)
//            {
//                return NotFound();
//            }
//            return View(student);
//        }

//        // -------------------------------------------
//        // POST: /Student/Edit/5
//        // Update student
//        // -------------------------------------------
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Address")] Models.Students student)
//        {
//            if (id != student.Id)
//            {
//                return NotFound();
//            }
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    await _studentRepository.UpdateStudentAsync(student);
//                }
//                catch (Exception)
//                {
//                    if (!await _studentRepository.StudentExistsAsync(student.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(student);
//        }

//        // -------------------------------------------
//        // GET: /Student/Delete/5
//        // Show delete confirmation
//        // -------------------------------------------
//        public async Task<IActionResult> Delete(int id)
//        {
//            var student = await _studentRepository.GetStudentByIdAsync(id);
//            if (student == null)
//            {
//                return NotFound();
//            }
//            return View(student);
//        }

//        // -------------------------------------------
//        // POST: /Student/Delete/5
//        // Confirm and delete the student
//        // -------------------------------------------
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var exists = await _studentRepository.StudentExistsAsync(id);
//            if (exists)
//            {
//                await _studentRepository.DeleteStudentAsync(id);
//            }
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using WebAppStudent_Repositary_Pattern.Repositories.Interfaces;
using WebAppStudent_Repositary_Pattern.Models;

namespace WebAppStudent_Repositary_Pattern.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Students student)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.AddStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Students student)
        {
            if (id != student.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _studentRepository.UpdateStudentAsync(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

