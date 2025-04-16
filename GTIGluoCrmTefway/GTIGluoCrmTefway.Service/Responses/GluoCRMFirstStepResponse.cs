using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Service.Responses
{
    public class GluoCRMFirstStepResponse
    {


        public bool success { get; set; }
        public Result result { get; set; }


        public class Result
        {
            public string token { get; set; }
            public int serverTime { get; set; }
            public int expireTime { get; set; }
        }

    }
}
