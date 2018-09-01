using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitApp.Models
{
    public class CreateActivityViewModels
    {
        public string Name { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Coach> Coachs { get; set; }
    }
}