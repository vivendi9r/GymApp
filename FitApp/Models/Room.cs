using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitApp.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string Name { get; set; }

        public ICollection<Activity> Activity { get; set; }

    }
}