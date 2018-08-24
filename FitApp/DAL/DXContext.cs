using FitApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FitApp.DAL
{
    public class DXContext : DbContext
    {
        public DXContext() : base("DefaultConnection")
        { }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual  DbSet<Coach> Coachs { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<ActivityUser> ActivitiesUsers { get; set; }

    }
}