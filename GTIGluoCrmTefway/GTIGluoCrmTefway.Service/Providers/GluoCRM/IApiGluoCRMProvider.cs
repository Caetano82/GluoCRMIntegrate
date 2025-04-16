using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Service.Providers.GluoCRM
{
    public interface IApiGluoCRMProvider
    {
        Task<string> GetAsync(string endpoint);

        Task<string> PostAsync(string endpoint, string content);
        Task<string> PostFormDataAsync(string endpoint, string operation, string username, string accessKey);


    }
}
