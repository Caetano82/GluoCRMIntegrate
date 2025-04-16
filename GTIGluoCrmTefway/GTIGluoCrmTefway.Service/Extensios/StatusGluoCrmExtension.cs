using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Service.Extensios
{
    public static class StatusGluoCrmExtension
    {

        public static int setStatusStarSoftByGluCRM(this string status)
        {
            //STATUS(1 - ATIVO, 2 - INATIVO, 3 - ESTUDO)

            if (status.ToLower() == "inativo") return 1;
            if (status.ToLower() == "ativo") return 2;
            if (status.ToLower() == "estudo") return 3;

            return 2;


        }
    }
}
