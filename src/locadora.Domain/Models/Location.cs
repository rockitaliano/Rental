using System;
using System.Collections.Generic;
using System.Text;

namespace locadora.Domain.Models
{
    public class Location
    {
        public Location(int customerId, int movieId, DateTime locationDate, DateTime? devolutionDate)
        {
            CustomerId = customerId;
            MovieId = movieId;
            LocationDate = locationDate;
            DevolutionDate = devolutionDate;
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime LocationDate { get; set; }
        public DateTime? DevolutionDate { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
