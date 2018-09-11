using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitApp.Models
{
    public class BMR
    {
        public float Weight { get; set; }
        public float Activity { get; set; }
        public bool SexMale { get; set; }
    }
}