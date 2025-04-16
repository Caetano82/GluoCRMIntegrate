using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Service.Requests
{
    public class GluoCRMOperationTypesRequest
    {
        public GluoCRMOperationTypesRequest(string operationFirst, string operationSecond, string operationQuery, string userName, string key, string queryContracts, string queryCustomer, string queryContacts)
        {
            this.operationFirst = operationFirst;
            this.operationSecond = operationSecond;
            this.operationQuery = operationQuery;
            UserName = userName;
            Key = key;
            this.queryContracts = queryContracts;
            this.queryCustomer = queryCustomer;
            this.queryContacts = queryContacts;
        }

        public string operationFirst { get; set; }
        public string operationSecond { get; set; }
        public string operationQuery { get; set; }
        public string UserName { get; set; }
        public string Key { get; set; }

        public string queryContracts { get; set; }
        public string queryCustomer { get; set; }
          public string queryContacts { get; set; }

        




    }
}