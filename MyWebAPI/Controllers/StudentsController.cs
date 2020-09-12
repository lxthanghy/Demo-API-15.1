using MyWebAPI.DTO;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace MyWebAPI.Controllers
{
    public class StudentsController : ApiController
    {
        // GET: api/Students
        public List<StudentDTO> Get()
        {
            using (EClassEntities db = new EClassEntities())
            {
                List<StudentDTO> students = new List<StudentDTO>();
                foreach (Student s in db.Students)
                    students.Add(new StudentDTO(s.StudentID, s.FullName, s.Birthday));
                return students;
            }
        }
        [HttpGet]
        public List<Student> LayStudentByGender(string gender)
        {
            List<Student> listStudent = null;
            using (EClassEntities db = new EClassEntities())
            {
                if (gender.ToLower().Equals("all"))
                    listStudent = db.Students.ToList();
                else if (gender.ToLower().Equals("female"))
                    listStudent = db.Students.Where(x => x.Gender.Value == false).ToList();
                else if (gender.ToLower().Equals("male"))
                    listStudent = db.Students.Where(x => x.Gender.Value == true).ToList();
            }
            return listStudent;

        }
        // GET: api/Students/5
        public Student Get(string id)
        {
            using (EClassEntities db = new EClassEntities())
            {
                Student s = db.Students.SingleOrDefault(x => x.StudentID == id);
                if (s != null)
                    //return new StudentDTO(s.StudentID, s.FullName, s.Birthday);
                    return s;
                else
                    return null;
            }
        }

        // POST: api/Students
        //public List<Student> Post([FromBody] Student student)
        //{
        //    using (EClassEntities db = new EClassEntities())
        //    {
        //        db.Students.Add(student);
        //        db.SaveChanges();
        //        return db.Students.ToList();
        //    }
        //}
        [HttpGet]
        public List<StudentPeriodDTO> GetTest()
        {
            using (EClassEntities db = new EClassEntities())
            {
                var list = from c in db.Students
                           join d in db.Classes
                           on c.ClassID equals d.ClassID
                           select new StudentPeriodDTO
                           {
                               StudentID = c.StudentID,
                               FullName = c.FullName,
                               Birthday = c.Birthday,
                               Period = d.Period
                           };
                return list.ToList();
            }
        }
        [HttpGet]
        public HttpResponseMessage GetTest1()
        {
            using (EClassEntities db = new EClassEntities())
            {
                var list = from c in db.Students
                           select new { c.StudentID, c.FullName, c.Class.Period };
                return Request.CreateResponse(HttpStatusCode.OK, list.ToList());
            }
        }
        [HttpPut]
        // PUT: api/Students/5
        public List<Student> EditStudent(string id, [FromBody] Student student)
        {
            using (EClassEntities db = new EClassEntities())
            {
                Student s = db.Students.SingleOrDefault(x => x.StudentID == id);
                if (s != null)
                {
                    s.FullName = student.FullName;
                    s.ClassID = student.ClassID;
                    s.Birthday = student.Birthday;
                    s.Address = student.Address;
                    s.Email = student.Email;
                    s.Gender = student.Gender;
                }
                db.SaveChanges();
                return db.Students.ToList();
            }
        }
        [HttpPost]
        public HttpResponseMessage AddStudent([FromBody] Student student)
        {
            try
            {
                using (EClassEntities db = new EClassEntities())
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        // DELETE: api/Students/5
        //public List<Student> Delete(string id)
        //{
        //    using (EClassEntities db = new EClassEntities())
        //    {
        //        Student s = db.Students.SingleOrDefault(x => x.StudentID == id);
        //        if (s != null)
        //            db.Students.Remove(s);
        //        db.SaveChanges();
        //        return db.Students.ToList();
        //    }
        //}
        public HttpResponseMessage Delete(string id)
        {
            try
            {
                using (EClassEntities db = new EClassEntities())
                {
                    Student s = db.Students.SingleOrDefault(x => x.StudentID == id);
                    if (s != null)
                        db.Students.Remove(s);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, s);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }
    }
}
