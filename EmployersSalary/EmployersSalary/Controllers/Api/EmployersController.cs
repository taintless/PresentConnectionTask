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
        public IHttpActionResult GetEmployers(string query = null)
        {
            var employers = _context.Employers;
            //if (!String.IsNullOrWhiteSpace(query))
            //{
            //    employers = _context.Employers.Where(e => e.FirstName.Contains(query));
            //}

            return Ok(employers);
        }

        // GET /api/employers/1
        public IHttpActionResult GetEmployer(int id)
        {
            var employer = _context.Employers.SingleOrDefault(c => c.Id == id);

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


            return Created(new Uri(Request.RequestUri + "/" + employer.Id), employer);
        }

        // PUT /api/employers/1
        [HttpPut]
        public IHttpActionResult UpdateEmployer(int id, Employer employer)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employerInDb = _context.Employers.SingleOrDefault(c => c.Id == id);

            if (employerInDb == null)
                return NotFound();

            Mapper.Map(employer, employerInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/employers/1
        [HttpDelete]
        public IHttpActionResult DeleteEmployer(int id)
        {
            var employerInDb = _context.Employers.SingleOrDefault(c => c.Id == id);

            if (employerInDb == null)
                return NotFound();

            _context.Employers.Remove(employerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
