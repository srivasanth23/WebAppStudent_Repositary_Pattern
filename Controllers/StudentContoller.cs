using Microsoft.AspNetCore.Mvc;
using WebAppStudent_Repositary_Pattern.Models;
using WebAppStudent_Repositary_Pattern.Repositories;
using WebAppStudent_Repositary_Pattern.Repositories.Interfaces;

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


        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid Student ID");
            }

            var student = await _studentRepository.GetStudentByIdAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

    }
}

