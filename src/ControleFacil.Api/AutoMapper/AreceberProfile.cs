using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFacil.Api.Contract.Areceber;
using ControleFacil.Api.Damain.Models;

namespace ControleFacil.Api.AutoMapper
{
    public class AreceberProfile : Profile
    {
        public AreceberProfile()
        {
            CreateMap<Areceber, AreceberRequestContract>().ReverseMap();
            CreateMap<Areceber, AreceberResponseContract>().ReverseMap();
        }
    }
}