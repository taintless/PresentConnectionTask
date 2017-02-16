using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using EmployersSalary.Models;

namespace EmployersSalary.Controllers.Api
{
    public class EmployersController : ApiController
    {
        private ApplicationDbContext _context;

        public EmployersController()
        {
            _context = new ApplicationDbContext();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    _context.Dispose();
        //}

        // GET /api/employers
        public IHttpActionResult GetEmployers()
        {
            var employers = _context.Employers;
            //if (!String.IsNullOrWhiteSpace(query))
            //{
            //    employers = employers.Where(e => e.FirstName.Contains(query));
            //}

            return Ok(employers);
        }

        // GET /api/employers/firstName/lastName
        [Route("api/employers/{firstName}/{lastName}")]
        public IHttpActionResult GetEmployer(string firstName, string lastName)
        {
            var employer = _context.Employers.SingleOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (employer == null)
                return NotFound();

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
        [Route("api/employers/{firstName}/{lastName}")]
        public IHttpActionResult UpdateEmployer(string firstName, string lastName, Employer employer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employerInDb = _context.Employers.SingleOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (employerInDb == null)
                return NotFound();

            employerInDb.FirstName = employer.FirstName;
            employerInDb.LastName = employer.LastName;
            employerInDb.NetSalary = employer.NetSalary;
            //Mapper.Map(employer, employerInDb);

            _context.SaveChanges();

            return Ok();
        }

        //// DELETE /api/employers/1
        //[HttpDelete]
        //public IHttpActionResult DeleteEmployer(int id)
        //{
        //    var employerInDb = _context.Employers.SingleOrDefault(c => c.Id == id);

        //    if (employerInDb == null)
        //        return NotFound();

        //    _context.Employers.Remove(employerInDb);
        //    _context.SaveChanges();

        //    return Ok();
        //}
    }
}
