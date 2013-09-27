using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class DemoLabModel
    {
        public List<int> Ids { get; set; }

        public List<string> Names { get; set; }

        public List<Person> Persons { get; set; }

        public string Description { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}