using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Site.Mappers
{
    public class AutoMapperConfig
    {
        //Registrar Mapas 
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
                {
                    x.AddProfile<ModelToViewModelProfile>(); //Adiciona Perfil de Model para ViewModel
                    x.AddProfile<ViewModelToModelProfile>(); //Adiciona Perfil de ViewModel para Model 
                }
            );
        }
    }
}