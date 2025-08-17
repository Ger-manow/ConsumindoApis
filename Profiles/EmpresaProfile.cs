using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

public class CepProfile : Profile
{
    public CepProfile()
    {
        CreateMap<CepDTO, Cep>();
    }
}
