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
       // GET: Employers
        public ViewResult Index()
        {
            //if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            //return View("ReadOnlyList");
        }
    }
}