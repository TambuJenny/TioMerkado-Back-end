using System.ComponentModel.DataAnnotations;
using DomaineService.Models.Request.Product;
using DomaineService.Models.Response.Product;
using DomainService.Interface.Product;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.Product
{
    [ApiController]
    [Route("api/[controller]")]
    public class PCController : ControllerBase
    {
        private readonly PCInterface _pcInterface;

        public PCController(PCInterface pcInterface)
        {
            _pcInterface = pcInterface;
        }

        [HttpPost]
        public async Task<ActionResult> Create([Required] [FromBody] PCRequest request)
        {
            try
            {
                await _pcInterface.Create(request);
                return Ok();
            }
            catch (NotImplementedException errorCreatePc)
            {
                switch (errorCreatePc.Message)
                {
                    case "Objeto vazio":
                        return BadRequest(errorCreatePc.Message);
                    case "Usuario selecionado não existe":
                        return NotFound(errorCreatePc.Message);
                    case "Marca selecionada não existe":
                        return NotFound(errorCreatePc.Message);

                    default:
                        return BadRequest(errorCreatePc.Message);
                }

                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([Required] [FromBody] PcResponse request)
        {
            try
            {
                await _pcInterface.Update(request);
                return Ok();
            }
            catch (NotImplementedException errorUpdatePc)
            {
                switch (errorUpdatePc.Message)
                {
                    case "Pc não existe":
                        return NotFound(errorUpdatePc.Message);
                    case "Usuario selecionado não existe":
                        return NotFound(errorUpdatePc.Message);
                    case "Marca selecionada não existe":
                        return NotFound(errorUpdatePc.Message);

                    default:
                        return BadRequest(errorUpdatePc.Message);
                }
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAllAvailable()
        {
            try
            {
                var allPcActive = await _pcInterface.GetAllAvailable();

                return Ok(allPcActive);
            }
            catch (NotImplementedException errorGetAllAvailable)
            {
                switch (errorGetAllAvailable.Message)
                {
                    case "Computador não existe":
                        return NotFound(errorGetAllAvailable.Message);

                    default:
                        return BadRequest(errorGetAllAvailable.Message);
                }
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var allPcActive = await _pcInterface.GetAll();

                return Ok(allPcActive);
            }
            catch (NotImplementedException errorGetAllAvailable)
            {
                switch (errorGetAllAvailable.Message)
                {
                    case "Computador não existe":
                        return NotFound(errorGetAllAvailable.Message);

                    default:
                        return BadRequest(errorGetAllAvailable.Message);
                }
            }
        }

        [HttpGet("[action]/{idPc}")]
        public async Task<ActionResult> GetById([FromRoute] Guid idPc)
        {
            try
            {
                var pcById = await _pcInterface.GetById(idPc);

                return Ok(pcById);
            }
            catch (NotImplementedException errorGetById)
            {
                switch (errorGetById.Message)
                {
                    case "Computador não existe":
                        return NotFound(errorGetById.Message);

                    default:
                        return BadRequest(errorGetById.Message);
                }
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([Required] [FromHeader(Name = "IdPc")] Guid id)
        {
            try
            {
                await _pcInterface.Delete(id);
                return Ok();
            }
            catch (NotImplementedException errorDeletePc)
            {
                switch (errorDeletePc.Message)
                {
                    case "Computador não existe":
                        return NotFound(errorDeletePc.Message);

                    default:
                        return BadRequest(errorDeletePc.Message);
                }
            }
        }
    }
}
