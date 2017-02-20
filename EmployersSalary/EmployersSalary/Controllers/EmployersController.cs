using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using EmployersSalary.Models;
using Microsoft.AspNet.Identity;

namespace EmployersSalary.Controllers
{
    [System.Web.Mvc.Authorize]
    public class EmployersController : Controller
    {
        private ApplicationDbContext _context;

        public EmployersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            
            if (User.IsInRole(RoleName.Admin))
                return View("List");
            if (User.IsInRole(RoleName.ProjectManager))
                return View("ListReadOnly");

            var loggedUserId = User.Identity.GetUserId();
            var user = _context.Users.Include(u => u.Employer).Single(u => u.Id == loggedUserId);
            var employer =
                _context.Employers.Single(
                    e => e.FirstName == user.Employer.FirstName && e.LastName == user.Employer.LastName);


            return View("ListEmployer", employer);
        }


        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        [System.Web.Mvc.HttpPost]
        public ActionResult Save(Employer employer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new Employer
                {
                    FirstName = employer.FirstName,
                    LastName = employer.LastName,
                    NetSalary = employer.NetSalary
                };

                return View("EmployerForm", viewModel);
            }

            var employerInDb =
                _context.Employers.Single(e => e.FirstName == employer.FirstName && e.LastName == employer.LastName);
            employerInDb.NetSalary = employer.NetSalary;

            _context.SaveChanges();

            return RedirectToAction("Index", "Employers");
        }

        [System.Web.Mvc.Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit([FromUri] string firstName, string lastName)
        {

            var employer = _context.Employers.SingleOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
            if (employer == null)
                return HttpNotFound();

            return View("EmployerForm", employer);
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null || file.ContentType.StartsWith("image/"))
            {
                var loggedUserId = User.Identity.GetUserId();
                var loggedUser = _context.Users.Include(u => u.Employer).Single(u => u.Id == loggedUserId);
                string pic = System.IO.Path.GetFileName(loggedUser.Employer.FirstName + loggedUser.Employer.LastName+ ".png");
                string path = System.IO.Path.Combine(
                                        Server.MapPath(MyConstants.profileImagesPath), pic);
                file.SaveAs(path);
                
            }
            return RedirectToAction("Index", "Employers");
        }
    }
}