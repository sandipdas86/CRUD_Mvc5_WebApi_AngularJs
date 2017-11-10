using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTApi.Models
{
    public class Employees
    {
        public int Emp_Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime DOB { get; set; }
        public int City { get; set; }
        public string Address { get; set; }
    }
    public class Country
    {
        public int Country_Id { get; set; }
        public string _Country { get; set; }
    }
    public class State
    {
        public int State_Id { get; set; }
        public string _State { get; set; }
        public int Fk_CountryId { get; set; }
    }
    public class City
    {
        public int City_Id { get; set; }
        public string _City { get; set; }
        public int Fk_StateId { get; set; }
    }
}