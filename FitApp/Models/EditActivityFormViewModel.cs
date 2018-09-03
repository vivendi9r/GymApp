using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitApp.Models
{
    public class EditActivityFormViewModel
    {
        public int ActivityId { get; set; }

        [DisplayName("Nazwa Aktywności")]
        public string Name { get; set; }
        [DisplayName("Data Rozpoczęcia")]

        public DateTime Start_time { get; set; }
        [DisplayName("Data Zakończenia")]

        public DateTime End_time { get; set; }
        public int CoachId { get; set; }
        public int RoomId { get; set; }
        [DisplayName("Sale do wyboru")]

        public List<SelectListItem> Rooms { get; set; }
        [DisplayName("Trenerzy do wyboru")]

        public List<SelectListItem> Coachs { get; set; }
    }
}