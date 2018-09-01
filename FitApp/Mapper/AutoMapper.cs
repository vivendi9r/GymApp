using FitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitApp.Mapper
{
    public static class AutoMapper
    {
        public static Activity Map(CreateActivityViewModels model)
        {
            return new Activity
            {
                Name = model.Name,
                Start_time = model.Start_time,
                End_time = model.End_time
                

            };
        }
    }
}