using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTApi.Models;

namespace RESTApi.Controllers
{
    public class EmployeeController : ApiController
    {
        DBEntities_ db = new DBEntities_();

        // GET api/employee/

        [ActionName("GetEmployees")]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            var data = db.GetEmployees_SP().Select(s => new Employees()
            {
                Emp_Id=s.Emp_Id,
                Name=s.Name,
                Sex=s.Sex,
                DOB=s.DOB,
                City=s.City,
                Address=s.Address
            }).ToList();
            if (data != null)
            {
                var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(data);
                response = Request.CreateResponse(HttpStatusCode.OK, json.ToString());
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, "ERROR");
            }
            return response;
        }

        // POST api/employee/

        [ActionName("AddEmployee")]
        public HttpResponseMessage Post([FromBody]Employees employee)
        {
            HttpResponseMessage response;
            var data = db.AddNewEmpDetails_SP(employee.Name, employee.Sex, employee.DOB, employee.City, employee.Address);
            if (data > 0)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Employee added");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, "ERROR");
            }
            return response;
        }

        // PUT api/employee/id

        [ActionName("EditEmployee")]
        public HttpResponseMessage Put([FromUri]int? Id,[FromBody]Employees employee)
        {
            HttpResponseMessage response;
            var data = db.UpdateEmpDetails_SP(Id,employee.Name, employee.Sex, employee.DOB, employee.City, employee.Address);
            if (data > 0)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Employee updated");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, "ERROR");
            }
            return response;
        }

        // DELETE api/employee/id

        [ActionName("DeleteEmployee")]
        public HttpResponseMessage Delete([FromUri]int? Id)
        {
            HttpResponseMessage response;
            var data = db.DeleteEmpById_SP(Id);
            if (data > 0)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Employee deleted");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.NotFound, "ERROR");
            }
            return response;
        }
    }
}
