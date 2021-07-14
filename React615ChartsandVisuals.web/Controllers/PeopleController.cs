using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using React615ChartsandVisuals.data;
using Faker;

namespace React615ChartsandVisuals.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private String _conn;
        public PeopleController(IConfiguration configuration)
        {
            _conn = configuration.GetConnectionString("ConStr");
        }

        [HttpGet]
        [Route("getpeople")]

        public List<Person> GetPeople()
        {
            var db = new PersonRepository(_conn);
            return db.GetPeople();
        }

        [HttpPost]
        [Route("addperson")]
        public void Add(Person p)
        {
            var db = new PersonRepository(_conn);
            db.AddPerson(p);
        }

  /*      [HttpPost]
        [Route("addmany")]
        public void AddPeople(SliderValues s)
        {
            var people = new List<Person>();
            var counter = 1;

            while (counter <= s.PplCount)
            {
                var first = Faker.Name.First();// random first
                var last = Faker.Name.Last(); //random last
                var age = Faker.RandomNumber.Next(s.MinAge, s.MaxAge); //random number between min and max
                var dob = DateTime.Now.AddYears(-age);
              
                var person = new Person
                {
                    FirstName = first,
                    LastName =  last,
                    Age = age,
                    DOB = dob
                };

                Add(person);
                counter++;
            }            
        }*/


        [HttpPost]
        [Route("addmany")]
        public void AddPeple(SliderValues s)
        {          

            var people = Enumerable.Range(1, s.PplCount).Select(_ => 
            {
                var age = Faker.RandomNumber.Next(s.MinAge, s.MaxAge); //random number between min and max
                var dob = DateTime.Now.AddYears(-age);

                return (new Person
                {
                    LastName = Faker.Name.Last(),
                    FirstName = Faker.Name.First(),
                    Age = age,
                    DOB = dob
                });
            });

            var db = new PersonRepository(_conn);
            db.AddPeople(people);
        }


        [HttpGet]
        [Route("agecategory")]
        public List<AgeCategory> AgeByBracket()
        {
            var db = new PersonRepository(_conn);
            return db.AgeByBracket();
        }

       


    }
}
