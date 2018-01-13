using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Site.Models;

namespace Site.Mappers
{
    public class ModelToViewModelProfile : Profile
    {

        public void Configure()
        {
            CreateMap<Pessoa, PessoaViewModel>();
        }


    }
}