using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Domain.Models
{
    public class Movie
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }
        public Movie(string name, bool available)
        {
            Name = name;
            Available = available;
        }

        private Movie() { }

    }
}
