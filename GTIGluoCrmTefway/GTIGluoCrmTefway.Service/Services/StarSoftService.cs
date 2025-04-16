using GTIGluoCrmTefway.InfraEsctruture.Context;
using GTIGluoCrmTefway.Respository.Dtos;
using GTIGluoCrmTefway.Respository.Interfaces;
using GTIGluoCrmTefway.Service.Extensios;
using GTIGluoCrmTefway.Service.Interfaces;
using GTIGluoCrmTefway.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Service.Services
{
    public class StarSoftService : IStarSoftService
    {
        private readonly IStarSoftRespository _starSoftRespository;
        private readonly IGluoCRMServices _gluoCRMServices;

        public StarSoftService(IStarSoftRespository starSoftRespository, IGluoCRMServices gluoCRMServices)
        {
            _starSoftRespository = starSoftRespository;
            _gluoCRMServices = gluoCRMServices;
        }

        public async Task<List<object>> CallSPCrmIntegraCliente()
        {
            List<object> listaResult = new List<object>();

            var customers = await _gluoCRMServices.GetCustomers();

            foreach (var customer in customers)
            {
                foreach (var result in customer.result)
                {
                    SPCrmIntegraClienteDTO parameters = SetProcCreateCustumerValues(result);

                    var resultado = await _starSoftRespository.CallSPCrmIntegraCliente(parameters);

                    var contact = await _gluoCRMServices.GetContacts(result.account_id);

                    if (contact.result?.Count > 0)
                    {

                        var contactDTO = setContactDto(contact.result.FirstOrDefault());

                        _starSoftRespository.addContact(contactDTO);

                    }

                    listaResult.Add(resultado);
                }
            }
            return listaResult;
        }

        private ContactDTO setContactDto(Contacts contact)
        {
            return new ContactDTO
            {
                A24_UKEY = contact.mailingcity,
                A23_UKEY = contact.mailingstate,
                A22_UKEY = contact.mailingcountry,
                A10_001_C = $"{contact.firstname} {contact.lastname}",
                A10_002_C = contact.mailingstreet,
                A10_003_C = contact.mailingbairro,
                A10_004_C = contact.mailingzip,
                A10_005_D = DateTime.Parse(contact.cf_2126),
                A10_007_C = contact.mailingnumero,
                A10_010A_C = contact.phone,
                A10_010B_C = contact.otherphone,
                A10_010C_C = contact.mobile,
                A10_010D_C = !string.IsNullOrEmpty(contact.email) ? contact.email : contact.secondaryemail,
                A10_021_C = contact.cpf,
                A10_022_C = contact.cf_1970,
                ARRAY_025 = int.TryParse(contact.cf_2318, out int array025) ? array025 : 0,
                A10_025_N = 0,
                A03_010_C = contact.account_id ?? contact.id
            };



        }

        private SPCrmIntegraClienteDTO SetProcCreateCustumerValues(ResultCustosmer result)
        {
            SPCrmIntegraClienteDTO parameters = new SPCrmIntegraClienteDTO();

            parameters.A03_002_C = result.accountname; // Nome do cliente
            parameters.A03_003_C = result.razao_social_cnpj; // Razão social
            parameters.A03_004_C = result.bill_bairro; // Bairro
            parameters.A03_005_C = result.bill_street; // Endereço (Rua)
            parameters.A03_006_C = result.bill_code; // CEP
            parameters.A03_014_C = result.bill_numero; // Número do endereço
            DateTime? A03_007_D = DateTime.Parse(result.createdtime); // Data do cadastro
            parameters.A03_008_M = result.description; // Observações/Comentários
            parameters.A03_010_C = result.cpfcnpj.getOnlyNumbers(); // CNPJ/CPF
            parameters.A03_011_C = result.inscricao_estadual; // Inscrição Estadual/RG
            parameters.A03_034_C = result.phone.Length == 12 ? result.phone.Substring(1, 2) : ""; // DDD Contato 1
            parameters.A03_035_C = result.phone.Length == 12 ? result.phone.Substring(5, 9) : ""; // Telefone Contato 1
            parameters.A03_037_C = result.nome_responsavel_conversao; // Nome Contato 1
            parameters.A03_038_C = ""; // customer.phone; // DDD Contato 2
            parameters.A03_039_C = "";//customer.phone; // Telefone Contato 2
            parameters.A03_041_C = ""; //customer.nome_responsavel_conversao; // Nome Contato 2
            parameters.A03_076_C = "";//  customer.phone; // Número Celular
            parameters.A03_043_C = result.email1; // Email 1
            parameters.A03_065_C = result.email2; // Email 2
            parameters.A03_150_N = 0; // customer.inscricao_estadual; // Indicação Simples Nacional
            parameters.A03_158_C = result.bill_complemento; // Complemento Endereço
            parameters.PAIS = ""; // Nome do País
            parameters.ESTADO = result.bill_state; // Sigla do Estado
            parameters.CIDADE = result.bill_city; // Nome da Cidade
            parameters.VENDEDOR = "0003"; // Código do Vendedor
            parameters.ARRAY_003 = result.accountstatus.setStatusStarSoftByGluCRM();// Parâmetro adicional


            return parameters;
        }
    }
}
