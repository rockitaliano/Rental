using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Domain.ViewModels.Location
{
    public class LocationQuery
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string MovieName { get; set; }
        public DateTime LocationDate { get; set; }
        public DateTime DevolutionDate { get; set; }

        public LocationQuery() { }
    }
}
