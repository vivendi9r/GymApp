using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitApp.Models
{
    public class ActivityEmailMessageViewModel
    {
        public string Name { get; set; }
        public DateTime Start_time { get; set; }
        public DateTime End_time { get; set; }
        public string Room { get; set; }
        public string Coach { get; set; }
    }
}