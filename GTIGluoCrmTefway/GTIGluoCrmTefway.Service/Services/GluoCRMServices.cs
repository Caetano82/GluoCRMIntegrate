using GTIGluoCrmTefway.IoC.Crypto.HashGenerator;
using GTIGluoCrmTefway.Service.Interfaces;
using GTIGluoCrmTefway.Service.Providers.GluoCRM;
using GTIGluoCrmTefway.Service.Requests;
using GTIGluoCrmTefway.Service.Responses;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;
using System.Collections.Generic;



namespace GTIGluoCrmTefway.Service.Services
{
    public class GluoCRMServices : IGluoCRMServices
    {
        private readonly IApiGluoCRMProvider _apiGluoCRMService;
        private readonly IConfiguration _configuration;
        private readonly GluoCRMOperationTypesRequest _gluoCRMOperationTypesRequest;


        public GluoCRMServices(IApiGluoCRMProvider apiGluoCRMService, IConfiguration configuration, GluoCRMOperationTypesRequest gluoCRMOperationTypesRequest)
        {
            _apiGluoCRMService = apiGluoCRMService;
            _configuration = configuration;
            _gluoCRMOperationTypesRequest = gluoCRMOperationTypesRequest;
        }

        public async Task<GluoSessionResponse> GetSession()
        {
            var first = await FirstStepAuth();

            if (first != null)
            {
                var sessionGluo = await GetSessionGluoApi(first);
                if (sessionGluo != null)
                {
                    return sessionGluo;
                }

            }
            return null;
        }

        private async Task<GluoSessionResponse> GetSessionGluoApi(GluoCRMFirstStepResponse first)
        {
            var hash = GeradorHash.GenerateMD5Hash(first.result.token, _gluoCRMOperationTypesRequest.Key);

            if (!string.IsNullOrEmpty(hash))
            {
                var requestData = new
                {
                    operation = _gluoCRMOperationTypesRequest.operationSecond,
                    username = _gluoCRMOperationTypesRequest.UserName,
                    accessKey = hash
                };

                var session = await _apiGluoCRMService.PostFormDataAsync("", requestData.operation, requestData.username, requestData.accessKey);

                return JsonConvert.DeserializeObject<GluoSessionResponse>(session);


            }

            return null;
        }

        private async Task<GluoCRMFirstStepResponse> FirstStepAuth()
        {
            string response = await _apiGluoCRMService.GetAsync($@"?operation={_gluoCRMOperationTypesRequest.operationFirst}&username={_gluoCRMOperationTypesRequest.UserName}");

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<GluoCRMFirstStepResponse>(response);

            }

            return null;
        }


        private async Task<string> GluoCRMQuery(string query, string sessionName)
        {

            // query = Uri.EscapeDataString(query);

            string response = await _apiGluoCRMService.GetAsync($@"?operation={_gluoCRMOperationTypesRequest.operationQuery}&sessionName={sessionName}&query={query}");

            if (!string.IsNullOrEmpty(response))
            {
                return response;

            }

            return null;

        }

        public async Task<GluoContracts> GetContracts()
        {
            var session = await GetSession();
            var response = await GluoCRMQuery(_gluoCRMOperationTypesRequest.queryContracts, session.result.sessionName);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<GluoContracts>(response);
            }

            return null;

        }

        public async Task<List<GluoCustumer>> GetCustomers()
        {

            List<GluoCustumer> listRetorno = new List<GluoCustumer>();
            var session = await GetSession();

            var contracts = await GetContracts();

            if (contracts == null)
                return null;

            var today = DateTime.Now.Date;
            var tomorrow = today.AddDays(1);


            for (var i = 0; i < contracts.result.Count; i++)
            {
                var customerAccounts = contracts.result.Select(x => x.sc_related_to).ToList().Take(20).Skip(i * 20);

                string result = String.Join(",", customerAccounts).TrimStart(',');

                var query = @$"{_gluoCRMOperationTypesRequest.queryCustomer} where id in({result}) and modifiedtime >= '{today:yyyy-MM-dd} 00:00:00' AND modifiedtime < '{tomorrow:yyyy-MM-dd} 00:00:00';";

                var response = await GluoCRMQuery(query, session.result.sessionName);

                if (!string.IsNullOrEmpty(response))
                {
                    var costumer = JsonConvert.DeserializeObject<GluoCustumer>(response);
                    if (costumer.result?.Count() > 0)
                    {
                        listRetorno.Add(costumer);

                        return listRetorno;
                    }
                }
            }

            return listRetorno;
        }

        public async Task<string> TestQuerys(string query)
        {
            var session = await GetSession();

            var response = await GluoCRMQuery(query, session.result.sessionName);

            if (!string.IsNullOrEmpty(response))
            {
                return response;
            }
            return "Erro";

        }

        public async Task<GluoContacts> GetContacts(string account_id)
        {
            var session = await GetSession();
            var response = await GluoCRMQuery($"{_gluoCRMOperationTypesRequest.queryContacts} where account_id ={account_id} ;", session.result.sessionName);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<GluoContacts>(response);
            }

            return null;
        }
    }
}
