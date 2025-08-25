using Microsoft.AspNetCore.Mvc;
using WebAppStudent_Repositary_Pattern.Models;
using WebAppStudent_Repositary_Pattern.Repositories.Interfaces;

namespace WebAppStudent_Repositary_Pattern.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: /Courses
        public async Task<IActionResult> Index()
        {
            var courses = await _courseRepository.GetAll();
            return View(courses);
        }

        // GET: /Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Courses courses)
        {
            if (ModelState.IsValid)
            {
                await _courseRepository.AddCourseAsync(courses);
                TempData["SuccessMessage"] = "Course created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(courses);
        }

        // GET: /Courses/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var course = await _courseRepository.GetById(id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        // POST: /Courses/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Courses courses)
        {
            if (id != courses.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _courseRepository.UpdateCourseAsync(courses);
                TempData["SuccessMessage"] = "Course updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(courses);
        }

        // GET: /Courses/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseRepository.GetById(id);
            if (course == null)
                return NotFound();

            return View(course);
        }

        // POST: Courses/DeleteConfirmed/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Get the course by id
            var course = await _courseRepository.GetById(id);

            // If not found, return 404
            if (course == null)
            {
                return NotFound();
            }

            // Delete the course from repository
            await _courseRepository.DeleteCourseAsync(id);

            // Redirect back to Index after deletion
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");

            var course = await _courseRepository.GetById(id);

            if (course == null)
                return NotFound("Course not found");

            return View(course);
        }

    }
}
