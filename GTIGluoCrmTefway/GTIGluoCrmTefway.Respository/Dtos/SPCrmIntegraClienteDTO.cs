using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Respository.Dtos
{
    public class SPCrmIntegraClienteDTO
    {
        public string A03_002_C { get; set; } // Nome do cliente
        public string A03_003_C { get; set; } // Razão social
        public string A03_004_C { get; set; } // Bairro
        public string A03_005_C { get; set; } // Endereço (Rua)
        public string A03_006_C { get; set; } // CEP
        public string A03_014_C { get; set; } // Número do endereço
        public DateTime? A03_007_D { get; set; } // Data do cadastro
        public string A03_008_M { get; set; } // Observações/Comentários
        public string A03_010_C { get; set; } // CNPJ/CPF
        public string A03_011_C { get; set; } // Inscrição Estadual/RG
        public string A03_034_C { get; set; } // DDD Contato 1
        public string A03_035_C { get; set; } // Telefone Contato 1
        public string A03_037_C { get; set; } // Nome Contato 1
        public string A03_038_C { get; set; } // DDD Contato 2
        public string A03_039_C { get; set; } // Telefone Contato 2
        public string A03_041_C { get; set; } // Nome Contato 2
        public string A03_076_C { get; set; } // Número Celular
        public string A03_043_C { get; set; } // Email 1
        public string A03_065_C { get; set; } // Email 2
        public int? A03_150_N { get; set; } // Indicação Simples Nacional
        public string A03_158_C { get; set; } // Complemento Endereço
        public string PAIS { get; set; } // Nome do País
        public string ESTADO { get; set; } // Sigla do Estado
        public string CIDADE { get; set; } // Nome da Cidade
        public string VENDEDOR { get; set; } // Código do Vendedor
        public int? ARRAY_003 { get; set; } // Parâmetro adicional
    }
}