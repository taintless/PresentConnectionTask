using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployersSalary.Models;

namespace EmployersSalary.Controllers
{
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
            //if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            //return View("ReadOnlyList");
        }

        public ActionResult New()
        {
            var employer = new Employer();
            return View("EmployerForm", employer);
        }

        [HttpPost]
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

            if (employer.Id == 0)
                _context.Employers.Add(employer);
            else
            {
                var employerInDb = _context.Employers.Single(c => c.Id == employer.Id);
                employerInDb.FirstName = employer.FirstName;
                employerInDb.LastName = employer.LastName;
                employerInDb.NetSalary = employer.NetSalary;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Employers");
        }

        public ActionResult Edit(int id)
        {
            var employer = _context.Employers.SingleOrDefault(c => c.Id == id);

            if (employer == null)
                return HttpNotFound();

            return View("EmployerForm", employer);
        }
    }
}