using GTIGluoCrmTefway.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GluoCRMController : ControllerBase
    {
        private readonly IGluoCRMServices _gluoCRMServices;
        private readonly IStarSoftService _starSoftService;

        public GluoCRMController(IGluoCRMServices gluoCRMServices, IStarSoftService starSoftService)
        {
            _gluoCRMServices = gluoCRMServices;
            _starSoftService = starSoftService;
        }

        [HttpGet("Session")]
        public async Task<IActionResult> GetAuthCRM()
        {
            var result = await _gluoCRMServices.GetSession();
            if (result == null)
            {
                return BadRequest("Não foi possivel autenticar no GluoCRM ");
            }
            return Ok(result);
        }

        [HttpGet("contracts")]
        public async Task<IActionResult> getContracts()
        {
            var result = await _gluoCRMServices.GetContracts();
            if (result == null)
            {
                return BadRequest("Não foi possivel listar os Contratos ");
            }
            return Ok(result);
        }

        [HttpGet("GluoCustomers")]
        public async Task<IActionResult> getGluoCustumers()
        {
            var result = await _gluoCRMServices.GetCustomers();
            if (result == null)
            {
                return BadRequest("Não foi possivel listar os Clientes ");
            }
            return Ok(result);
        }
        
        [HttpGet("GluoContacts")]
        public async Task<IActionResult> getGluoContacts(string sc_related_to)
        {
            var result = await _gluoCRMServices.GetContacts(sc_related_to);
            if (result == null)
            {
                return BadRequest("Não foi possivel listar os Clientes ");
            }
            return Ok(result);
        }

        [HttpGet("Query")]
        public async Task<IActionResult> GetQuery(string query)
        {
            var result = await _gluoCRMServices.TestQuerys(query);

            return Ok(result);
        }

        [HttpGet("IntegraClienteFromGluoToStarsoft")]
        public async Task<IActionResult> IntegraClienteFromGluoToStarsoft()
        {
            var result = await _starSoftService.CallSPCrmIntegraCliente();

            return Ok(result);
        }
    }
}
