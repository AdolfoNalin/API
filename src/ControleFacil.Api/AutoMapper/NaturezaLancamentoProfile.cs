using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFacil.Api.Contract.NaturezaLancamento;
using ControleFacil.Api.Damain.Models;

namespace ControleFacil.Api.AutoMapper
{
    public class NaturezaLancamentoProfile : Profile
    {
        public NaturezaLancamentoProfile()
        {
            CreateMap<NaturezaLancamento, NaturezaLancamentoRequestContract>().ReverseMap();
            CreateMap<NaturezaLancamento, NaturezaLancamentoResponseContract>().ReverseMap();
        }
    }
}