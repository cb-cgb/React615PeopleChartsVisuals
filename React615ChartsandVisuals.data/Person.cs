using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace React615ChartsandVisuals.data
{

    public class Person
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DOB { get; set; }
        // public int? Age => CalculateAge(DOB);

        private int? _age;

        public int? Age
        {  get {  _age = CalculateAge(DOB);  return _age; } set => _age = value; }

        [NotMapped]
        public String AgeBracket { get; set; }//=> AgeCategory(Age);




        private int CalculateAge(DateTime dob)
        {
             var today = DateTime.Today;

             var age = today.Year - dob.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (dob.Date > today.AddYears(-age)) age--;

            return age;
        }

       
    }

}

