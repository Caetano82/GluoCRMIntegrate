using GTIGluoCrmTefway.Respository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Respository.Interfaces
{
    public interface IStarSoftRespository
    {
     
        Task<(int ErrorCode, string Message, string UKey)> CallSPCrmIntegraCliente(SPCrmIntegraClienteDTO parameters);
        Task<(int errorCode, string message, string ukey)> addContact(ContactDTO contact);



    }
}

