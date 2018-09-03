using AutoMapper;
using FitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitApp
{
    public static class Automapper
    {
        private static IMapper Mapper { get; set; }
        public static IMapper  GetInstance()
        {
            if (Mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {

                    cfg.CreateMap<CreateActivityViewModels, Activity>();
                    cfg.CreateMap<Activity, CreateActivityViewModels>();
                    cfg.CreateMap<Activity, EditActivityFormViewModel>();
                    cfg.CreateMap<EditActivityFormViewModel, Activity>();




                });
                Mapper = config.CreateMapper();
            }
            return Mapper;
            
        }
    }
}