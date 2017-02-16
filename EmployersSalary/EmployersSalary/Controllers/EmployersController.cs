using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
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

        //public ActionResult New()
        //{
        //    var employer = new Employer();
        //    return View("EmployerForm", employer);
        //}

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

       // [Route("/employers/{firstName}/{lastName}")]
        public ActionResult Edit([FromUri] string firstName, string lastName)
        {

            var employer = _context.Employers.SingleOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
            if (employer == null)
                return HttpNotFound();

            return View("EmployerForm", employer);
        }
    }
}