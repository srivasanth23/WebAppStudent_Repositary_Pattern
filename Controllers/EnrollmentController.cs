using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppStudent_Repositary_Pattern.Models;
using WebAppStudent_Repositary_Pattern.Repositories.Interfaces;

namespace WebAppStudent_Repositary_Pattern.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentRepo _EnrollmentRepo;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public EnrollmentController(
            IEnrollmentRepo EnrollmentRepo,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository)
        {
            _EnrollmentRepo = EnrollmentRepo;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        // =============================
        // GET: /Enrollment
        // =============================
        public async Task<IActionResult> Index()
        {
            var enrollments = await _EnrollmentRepo.GetAllEnrollments();
            return View(enrollments);
        }

        // =============================
        // GET: /Enrollment/Details/{id}
        // =============================
        public async Task<IActionResult> Details(int id)
        {
            var enrollment = await _EnrollmentRepo.GetEnrollmentbyId(id);
            if (enrollment == null)
                return NotFound();

            return View(enrollment);
        }

        // =============================
        // GET: /Enrollment/Create
        // =============================
        public async Task<IActionResult> Create()
        {
            await BindDropdowns();
            return View();
        }

        // =============================
        // POST: /Enrollment/Create
        // =============================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Enrollments enrollment)
        {
            if (ModelState.IsValid)
            {
                await _EnrollmentRepo.AddEnrollmentsAsync(enrollment);
                return RedirectToAction(nameof(Index));
            }

            await BindDropdowns(enrollment.StudentId, enrollment.CourseId);
            return View(enrollment);
        }

        // =============================
        // GET: /Enrollment/Edit/{id}
        // =============================
        public async Task<IActionResult> Edit(int id)
        {
            var enrollment = await _EnrollmentRepo.GetEnrollmentbyId(id);
            if (enrollment == null)
                return NotFound();

            await BindDropdowns(enrollment.StudentId, enrollment.CourseId);
            return View(enrollment);
        }

        // =============================
        // POST: /Enrollment/Edit/{id}
        // =============================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Enrollments enrollment)
        {
            if (id != enrollment.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _EnrollmentRepo.UpdateEnrollmentsAsync(id, enrollment);
                return RedirectToAction(nameof(Index));
            }

            await BindDropdowns(enrollment.StudentId, enrollment.CourseId);
            return View(enrollment);
        }

        // =============================
        // GET: /Enrollment/Delete/{id}
        // =============================
        public async Task<IActionResult> Delete(int id)
        {
            var enrollment = await _EnrollmentRepo.GetEnrollmentbyId(id);
            if (enrollment == null)
                return NotFound();

            return View(enrollment);
        }

        // =============================
        // POST: /Enrollment/Delete/{id}
        // =============================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _EnrollmentRepo.DeleteEnrollmentsAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // =============================
        // Private Helper Method
        // =============================
        private async Task BindDropdowns(int? studentId = null, int? courseId = null)
        {
            ViewBag.StudentId = new SelectList(
                await _studentRepository.GetAllStudentsAsync(),
                "Id",
                "Name",
                studentId
            );

            ViewBag.CourseId = new SelectList(
                await _courseRepository.GetAll(),
                "Id",
                "Name",
                courseId
            );
        }
    }
}
