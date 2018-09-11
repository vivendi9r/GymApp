using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitApp.Models
{
    public class ActivityViewModel
    {
        public int ActivityId { get; set; }

        public string Name { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public string Room { get; set; }
        public string Coach { get; set; }
        public int AvailablePlaces { get; set; }
        public int OccupiedPlaces { get; set; }
        public bool Participant { get; set; }
        public Guid UserId { get; set; }

    }
}