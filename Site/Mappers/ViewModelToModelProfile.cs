using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Site.Models;

namespace Site.Mappers
{
    public class ViewModelToModelProfile : Profile
    {
        public void Configure()
        {
            CreateMap<PessoaViewModel, Pessoa>();
        }
    }
}