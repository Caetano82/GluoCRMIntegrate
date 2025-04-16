using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Service.Responses
{
    public class GluoContracts
    {


        public bool success { get; set; }
        public List<ResultContracts> result  = new List<ResultContracts>();

    }
    public class ResultContracts
    {
        public string assigned_user_id { get; set; }
        public string createdtime { get; set; }
        public string modifiedtime { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string sc_related_to { get; set; }
        public string tracking_unit { get; set; }
        public string total_units { get; set; }
        public string used_units { get; set; }
        public string subject { get; set; }
        public string due_date { get; set; }
        public string planned_duration { get; set; }
        public string actual_duration { get; set; }
        public string contract_status { get; set; }
        public string contract_priority { get; set; }
        public string contract_type { get; set; }
        public string progress { get; set; }
        public string contract_no { get; set; }
        public string modifiedby { get; set; }
        public string created_user_id { get; set; }
        public string helpdeskslaid { get; set; }
        public string source { get; set; }
        public string starred { get; set; }
        public string tags { get; set; }
        public string cf_1312 { get; set; }
        public string rel_revenda { get; set; }
        public string cf_1350 { get; set; }
        public string rel_software_house { get; set; }
        public string cf_1353 { get; set; }
        public string cf_1355 { get; set; }
        public string cf_1357 { get; set; }
        public string cf_1359 { get; set; }
        public string cf_1412 { get; set; }
        public string cf_1436 { get; set; }
        public string cf_1784 { get; set; }
        public string cf_1789 { get; set; }
        public string cf_1791 { get; set; }
        public string cf_1833 { get; set; }
        public string cf_1834 { get; set; }
        public string cf_1835 { get; set; }
        public string cf_1849 { get; set; }
        public string status_gestao_itens { get; set; }
        public string status_itens { get; set; }
        public string valor_contrato { get; set; }
        public string valor_comissao_contrato { get; set; }
        public string cancelamento_total_status { get; set; }
        public string cancelamento_total_solicitacao { get; set; }
        public string cancelamento_total_rejeicao { get; set; }
        public string status_assinatura { get; set; }
        public string contrato_legado { get; set; }
        public string cf_2143 { get; set; }
        public string cf_2218 { get; set; }
        public string cf_2234 { get; set; }
        public string date_update_cancel_items { get; set; }
        public string id { get; set; }
    }

}

