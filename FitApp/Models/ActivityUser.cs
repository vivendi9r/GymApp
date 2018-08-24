using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitApp.Models
{
    public class ActivityUser
    {
        [Key]
        public int ActivitiesUsersId { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
    }
}