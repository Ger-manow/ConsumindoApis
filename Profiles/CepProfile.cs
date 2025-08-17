using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

public class EmpresaProfile : Profile
{
    public EmpresaProfile()
    {
        CreateMap<CnpjResponseDTO, Empresa>();
    }
}
