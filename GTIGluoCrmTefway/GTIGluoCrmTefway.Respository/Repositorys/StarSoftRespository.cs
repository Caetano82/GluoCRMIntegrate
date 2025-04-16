using GTIGluoCrmTefway.InfraEsctruture.Context;
using GTIGluoCrmTefway.Respository.Dtos;
using GTIGluoCrmTefway.Respository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Respository.Repositorys
{
    public class StarSoftRespository : IStarSoftRespository
    {
        private readonly DBContextSQL _context;

        public StarSoftRespository(DBContextSQL context)
        {
            _context = context;
        }

        public async Task<(int errorCode, string message, string ukey)> addContact(ContactDTO contact)
        {
            var commandText = "[SP_CRM_INTEGRA_CONTATO]";
            var parametersList = new[]
            {
        new SqlParameter("@A24_UKEY", contact.A24_UKEY ?? (object)DBNull.Value),
        new SqlParameter("@A23_UKEY", contact.A23_UKEY ?? (object)DBNull.Value),
        new SqlParameter("@A22_UKEY", contact.A22_UKEY ?? (object)DBNull.Value),
        new SqlParameter("@A10_001_C", contact.A10_001_C ?? (object)DBNull.Value),
        new SqlParameter("@A10_002_C", contact.A10_002_C ?? (object)DBNull.Value),
        new SqlParameter("@A10_003_C", contact.A10_003_C ?? (object)DBNull.Value),
        new SqlParameter("@A10_004_C", contact.A10_004_C ?? (object)DBNull.Value),
        new SqlParameter("@A10_005_D", contact.A10_005_D),
        new SqlParameter("@A10_006_C", contact.A10_006_C ?? (object)DBNull.Value),
        new SqlParameter("@A10_007_C", contact.A10_007_C ?? (object)DBNull.Value),
        new SqlParameter("@ARRAY_024A", contact.ARRAY_024A),
        new SqlParameter("@A10_010A_C", contact.A10_010A_C ?? (object)DBNull.Value),
        new SqlParameter("@A10_011A_C", contact.A10_011A_C ?? (object)DBNull.Value),
        new SqlParameter("@ARRAY_024B", contact.ARRAY_024B),
        new SqlParameter("@A10_010B_C", contact.A10_010B_C ?? (object)DBNull.Value),
        new SqlParameter("@A10_011B_C", contact.A10_011B_C ?? (object)DBNull.Value),
        new SqlParameter("@ARRAY_024C", contact.ARRAY_024C),
        new SqlParameter("@A10_010C_C", contact.A10_010C_C ?? (object)DBNull.Value),
        new SqlParameter("@ARRAY_024D", contact.ARRAY_024D),
        new SqlParameter("@A10_010D_C", contact.A10_010D_C ?? (object)DBNull.Value),
        new SqlParameter("@A10_021_C", contact.A10_021_C ?? (object)DBNull.Value),
        new SqlParameter("@A10_022_C", contact.A10_022_C ?? (object)DBNull.Value),
        new SqlParameter("@ARRAY_022", contact.ARRAY_022),
        new SqlParameter("@ARRAY_025", contact.ARRAY_025),
        new SqlParameter("@ARRAY_E08", contact.ARRAY_E08),
        new SqlParameter("@A10_025_N", contact.A10_025_N),
        new SqlParameter("@A03_010_C", contact.A03_010_C ?? (object)DBNull.Value)
    };

            // Ensure connection string is set
            var connectionString = _context.Database.GetConnectionString();
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not initialized.");
            }

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parametersList);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            int errorCode = reader.GetInt32(reader.GetOrdinal("ERRO"));
                            string message = reader.GetString(reader.GetOrdinal("MENSAGEM"));
                            string ukey = reader.GetString(reader.GetOrdinal("UKEY"));

                            return (errorCode, message, ukey);
                        }
                    }
                }
            }

            return (0, "Procedure didn't return expected result", null);
        }


        public async Task<(int ErrorCode, string Message, string UKey)> CallSPCrmIntegraCliente(SPCrmIntegraClienteDTO parameters)
        {
            var commandText = "[SP_CRM_INTEGRA_CLIENTE]";
            var parametersList = new[]
            {
                new SqlParameter("@A03_002_C", parameters.A03_002_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_003_C", parameters.A03_003_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_004_C", parameters.A03_004_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_005_C", parameters.A03_005_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_006_C", parameters.A03_006_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_014_C", parameters.A03_014_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_007_D", parameters.A03_007_D ?? DateTime.Now),
                new SqlParameter("@A03_008_M", parameters.A03_008_M ?? (object)DBNull.Value),
                new SqlParameter("@A03_010_C", parameters.A03_010_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_011_C", parameters.A03_011_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_034_C", parameters.A03_034_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_035_C", parameters.A03_035_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_037_C", parameters.A03_037_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_038_C", parameters.A03_038_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_039_C", parameters.A03_039_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_041_C", parameters.A03_041_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_076_C", parameters.A03_076_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_043_C", parameters.A03_043_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_065_C", parameters.A03_065_C ?? (object)DBNull.Value),
                new SqlParameter("@A03_150_N", parameters.A03_150_N ?? (object)DBNull.Value),
                new SqlParameter("@A03_158_C", parameters.A03_158_C ?? (object)DBNull.Value),
                new SqlParameter("@PAIS", parameters.PAIS ?? (object)DBNull.Value),
                new SqlParameter("@ESTADO", parameters.ESTADO ?? (object)DBNull.Value),
                new SqlParameter("@CIDADE", parameters.CIDADE ?? (object)DBNull.Value),
                new SqlParameter("@VENDEDOR", parameters.VENDEDOR ?? (object)DBNull.Value),
                new SqlParameter("@ARRAY_003", parameters.ARRAY_003 ?? (object)DBNull.Value),
            };

            // Ensure connection string is set
            var connectionString = _context.Database.GetConnectionString();
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string is not initialized.");
            }

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parametersList);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            int errorCode = reader.GetInt32(reader.GetOrdinal("ERRO"));
                            string message = reader.GetString(reader.GetOrdinal("MENSAGEM"));
                            string ukey = reader.GetString(reader.GetOrdinal("UKEY"));

                            return (errorCode, message, ukey);
                        }
                    }
                }
            }

            return (0, "Procedure didn't return expected result", null);
        }
    }
}
