using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_apps_3.Data;
using test_apps_3.Models.DomainModel;
using test_apps_3.Models.ViewModel;

namespace test_apps_3.Controllers
{
    public class AdminStudentController : Controller
    {
        private readonly AppsDbContext _appsDbContext;

        public AdminStudentController(AppsDbContext appsDbContext)
        {
            this._appsDbContext = appsDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddStudentRequest addStudentRequest)
        {
            if (ModelState.IsValid)
            {
                var student = new StudentClass
                {
                    Name = addStudentRequest.Name,
                    Email = addStudentRequest.Email,
                    session = addStudentRequest.session,
                    Address = addStudentRequest.Address,
                    Gender = addStudentRequest.Gender,
                    Date = addStudentRequest.Date
                };

                if (addStudentRequest.ProfileImage != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await addStudentRequest.ProfileImage.CopyToAsync(ms);
                        student.ProfilePicture = ms.ToArray();
                    }
                }

                _appsDbContext._StudentsTable.Add(student);
                await _appsDbContext.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return View(addStudentRequest);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var studentList = await _appsDbContext._StudentsTable.ToListAsync();
            return View(studentList);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var studentEdit = await _appsDbContext._StudentsTable.FirstOrDefaultAsync(x => x.Id == id);
            if (studentEdit != null)
            {
                var editStudentRequest = new EditStudentRequest
                {
                    Id = studentEdit.Id,
                    Name = studentEdit.Name,
                    Email = studentEdit.Email,
                    session = studentEdit.session,
                    Address = studentEdit.Address,
                    Gender = studentEdit.Gender,
                    Date = studentEdit.Date,
                    ExistingProfilePicture = studentEdit.ProfilePicture
                };
                return View(editStudentRequest);
            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditStudentRequest editStudentRequest)
        {
            var existingStudent = await _appsDbContext._StudentsTable.FindAsync(editStudentRequest.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = editStudentRequest.Name;
                existingStudent.Email = editStudentRequest.Email;
                existingStudent.session = editStudentRequest.session;
                existingStudent.Address = editStudentRequest.Address;
                existingStudent.Gender = editStudentRequest.Gender;
                existingStudent.Date = editStudentRequest.Date;

                if (editStudentRequest.ProfileImage != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await editStudentRequest.ProfileImage.CopyToAsync(ms);
                        existingStudent.ProfilePicture = ms.ToArray();
                    }
                }

                await _appsDbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var studentDelete = await _appsDbContext._StudentsTable.FindAsync(id);
            if (studentDelete != null)
            {
                _appsDbContext._StudentsTable.Remove(studentDelete);
                await _appsDbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
    }
}