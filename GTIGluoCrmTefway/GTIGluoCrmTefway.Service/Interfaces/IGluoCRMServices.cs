using GTIGluoCrmTefway.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Service.Interfaces
{
    public interface IGluoCRMServices
    {
        Task<GluoSessionResponse> GetSession();

        Task<GluoContracts> GetContracts();

        Task<List<GluoCustumer>> GetCustomers();

        Task<GluoContacts> GetContacts(string account_id);

        Task<string> TestQuerys(string query);
    }
}
