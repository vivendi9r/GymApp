using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitApp.Models
{
    public class BMR
    {
        public int Weight { get; set; }
        public int Activity { get; set; }
        public bool SexMale { get; set; }
    }
}