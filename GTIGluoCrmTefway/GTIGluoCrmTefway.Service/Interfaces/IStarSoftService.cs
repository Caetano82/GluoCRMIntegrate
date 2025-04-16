using GTIGluoCrmTefway.Respository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Service.Interfaces
{
    public interface IStarSoftService
    {
        Task<List<object>> CallSPCrmIntegraCliente();


    }
}

