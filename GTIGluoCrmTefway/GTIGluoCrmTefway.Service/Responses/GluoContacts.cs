using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Service.Responses
{
    public class GluoContacts
    {
   
   
        public bool success { get; set; }
        public List<Contacts> result { get; set; }
    }

    public class Contacts
    {
        public string salutationtype { get; set; }
        public string firstname { get; set; }
        public string contact_no { get; set; }
        public string phone { get; set; }
        public string lastname { get; set; }
        public string mobile { get; set; }
        public string account_id { get; set; }
        public string homephone { get; set; }
        public string leadsource { get; set; }
        public string otherphone { get; set; }
        public string title { get; set; }
        public string fax { get; set; }
        public string department { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public string contact_id { get; set; }
        public string assistant { get; set; }
        public string secondaryemail { get; set; }
        public string assistantphone { get; set; }
        public string donotcall { get; set; }
        public string emailoptout { get; set; }
        public string assigned_user_id { get; set; }
        public string reference { get; set; }
        public string notify_owner { get; set; }
        public string createdtime { get; set; }
        public string modifiedtime { get; set; }
        public string modifiedby { get; set; }
        public string portal { get; set; }
        public string support_start_date { get; set; }
        public string support_end_date { get; set; }
        public string mailingstreet { get; set; }
        public string otherstreet { get; set; }
        public string mailingcity { get; set; }
        public string othercity { get; set; }
        public string mailingstate { get; set; }
        public string otherstate { get; set; }
        public string mailingzip { get; set; }
        public string otherzip { get; set; }
        public string mailingcountry { get; set; }
        public string othercountry { get; set; }
        public string mailingpobox { get; set; }
        public string otherpobox { get; set; }
        public string imagename { get; set; }
        public string description { get; set; }
        public string isconvertedfromlead { get; set; }
        public string mailingbairro { get; set; }
        public string other_bairro { get; set; }
        public string mailingbuscacep { get; set; }
        public string otherbuscacep { get; set; }
        public string cpf { get; set; }
        public string etapa_atual_contato { get; set; }
        public string contactstatus { get; set; }
        public string data_conv { get; set; }
        public string comp_pontuacao { get; set; }
        public string perfil { get; set; }
        public string followup_data { get; set; }
        public string followup_hora { get; set; }
        public string followup_usuario { get; set; }
        public string followup_realizado { get; set; }
        public string data_do_ultimo_agendamento { get; set; }
        public string source { get; set; }
        public string starred { get; set; }
        public string tags { get; set; }
        public string created_user_id { get; set; }
        public string eventstatus { get; set; }
        public string mailingnumero { get; set; }
        public string othernumero { get; set; }
        public string mailingcomplemento { get; set; }
        public string othercomplemento { get; set; }
        public string responsavel_ultimo_agendamento { get; set; }
        public string cf_1970 { get; set; }
        public string emailoptout_data { get; set; }
        public string emailoptout_motivo { get; set; }
        public string emailoptout_descricao { get; set; }
        public string liberar_chamados_filiais { get; set; }
        public string cf_2124 { get; set; }
        public string cf_2126 { get; set; }
        public string cf_2128 { get; set; }
        public string nome_responsavel_conversao { get; set; }
        public string ult_responsavel_lead { get; set; }
        public string id_lead_conv { get; set; }
        public string cf_2318 { get; set; }
        public string id { get; set; }
    }

}

