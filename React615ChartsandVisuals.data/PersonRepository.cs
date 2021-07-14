using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace React615ChartsandVisuals.data
{
    public class PersonRepository
    {
        private String _conn;

        public PersonRepository(String connection)
        {
            _conn = connection;
        }


        public List<Person> GetPeople()
        {
            using (var context = new PersonContext(_conn))
            {
                return context.People.OrderBy(p=> p.DOB).ToList();
            }
        }

        public void AddPerson(Person p)
        {
            using (var context = new PersonContext(_conn))
            {
               
                context.People.Add(p);
                context.SaveChanges();
            }
        }

        public void AddPeople(IEnumerable<Person> people)
        {
            using (var context = new PersonContext(_conn))
            {

                context.People.AddRange(people);
                context.SaveChanges();
            }
        }

        public List<AgeCategory> AgeByBracket()
        {
            using (var context = new PersonContext(_conn))
            {

                var ppl = context.People.Select(p => new Person
                {
                    Id = p.Id,
                    AgeBracket = AgeCategory(p.Age)

                }).ToList();

                var grouped = ppl.OrderBy(p=> p.AgeBracket).GroupBy(p => p.AgeBracket).Select(a => new AgeCategory
                {
                    AgeBracket = a.Key,
                    PeopleCount = a.Count()
                }).ToList();

                return grouped;
            }
        }

        static string AgeCategory(int? age)
        {
          
            var decadestart = (age/10)*10;
            var decadeend =  decadestart + 10;
            if (decadestart >0)
            {
                decadestart++;
                decadeend = decadestart + 9;
            }

            string label = $"{decadestart}-{decadeend}";
            return label;         
        }

     /*   static string AgeCategory2(int? age)
        {

        if (age >= 0 && age <= 10)
        {
            return "0-10";
        }
        else if (age > 10 && age <= 20)
        {
            return "11-20";
        }

        else if (age > 20 && age <= 30)
        {
            return "21-30";
        }

        else if (age > 30 && age <= 40)
        {
            return "31 - 40";
        }
        else if (age > 40 && age <= 50)
        {
            return "41-50";
        }
        else if (age > 50 && age <= 60)
        {
            return "51-60";
        }
        else if (age > 60 && age <= 70)
        {
            return "61-70";
        }
        else if (age > 70 && age <= 80)
        {
            return "71-80";
        }
        else if (age > 80)
        {
            return "80+";
        }
        else
        {
            return "no age";
        }

    } */


 }

}
