using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Web.Security;
using EmployersSalary.Models;
using Microsoft.AspNet.Identity;

namespace EmployersSalary.Controllers.Api
{
    public class EmployersController : ApiController
    {
        private ApplicationDbContext _context;

        public EmployersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/employers
        [Route("api/employers")]
        public IHttpActionResult GetEmployers()
        {
            var employers = _context.Employers.Where(e => e.FirstName != "Admin");

            return Ok(employers);
        }

        // GET /api/employers/firstName/lastName
        [Route("api/employer")]
        public IHttpActionResult GetEmployer([FromUri] string firstName, string lastName)
        {
            var employer = _context.Employers.SingleOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (employer == null)
                return NotFound();

            return Ok(employer);
        }

        // GET /api/employers
        [Route("api/loggedEmployer")]
        public IHttpActionResult GetLoggedEmployer()
        {
            var loggedUserId = User.Identity.GetUserId();
            var user = _context.Users.Include(u => u.Employer).Single(u => u.Id == loggedUserId);
            var employer =
                _context.Employers.Single(
                    e => e.FirstName == user.Employer.FirstName || e.LastName == user.Employer.LastName);

            return Ok(employer);
        }

        // POST /api/employers
        [HttpPost]
        public IHttpActionResult CreateEmployer(Employer employer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Employers.Add(employer);
            _context.SaveChanges();


            return Created(new Uri(Request.RequestUri + "/" + employer.FirstName + "/" + employer.LastName), employer);
        }

        // PUT /api/employers/1
        [HttpPut]
        [Route("api/employers")]
        public IHttpActionResult UpdateEmployer([FromUri] string firstName, string lastName, Employer employer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employerInDb = _context.Employers.SingleOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (employerInDb == null)
                return NotFound();

            employerInDb.FirstName = employer.FirstName;
            employerInDb.LastName = employer.LastName;
            employerInDb.NetSalary = employer.NetSalary;

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/employers/1
        [HttpDelete]
        [Route("api/employers")]
        public IHttpActionResult DeleteEmployer([FromUri] string firstName, string lastName)
        {
            var employerInDb = _context.Employers.SingleOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (employerInDb == null)
                return NotFound();

            _context.Employers.Remove(employerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}