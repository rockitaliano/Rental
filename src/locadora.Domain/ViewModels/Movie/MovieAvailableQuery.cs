using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace locadora.Domain.ViewModels.Movie
{
    public class MovieAvailableQuery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        private MovieAvailableQuery() { }
    }
}
