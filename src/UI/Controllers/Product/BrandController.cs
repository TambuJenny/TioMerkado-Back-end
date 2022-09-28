using System.ComponentModel.DataAnnotations;
using DomaineService.Models.Request.Product;
using DomainService.Interface.Product;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Product
{
    [ApiController]
    [Route("api/product/[Controller]")]
    public class BrandController : ControllerBase
    {
        private readonly BrandInterface _brandInteface;

        public BrandController(BrandInterface brandInteface)
        {
            _brandInteface = brandInteface;
        }

        [HttpPost]
        public async Task<ActionResult> Create([Required] [FromBody] BrandRequest request)
        {
            try
            {
                await _brandInteface.Create(request);
                return Ok();
            }
            catch (NotImplementedException errorCreateBrand)
            {
                switch (errorCreateBrand.Message)
                {
                    case "A marca já existe":
                        return BadRequest(errorCreateBrand.Message);

                    default:
                        return BadRequest(errorCreateBrand.Message);
                }
                throw;
            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> GetById([Required] [FromRoute] Guid id)
        {
            try
            {
                var response = await _brandInteface.GetById(id);
                return Ok(response);
            }
            catch (NotImplementedException errorCreateBrand)
            {
                switch (errorCreateBrand.Message)
                {
                    case "A marca não existe":
                        return BadRequest(errorCreateBrand.Message);

                    default:
                        return BadRequest(errorCreateBrand.Message);
                }
                throw;
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult>GetAll()
        {
            try
            {
                var response = await _brandInteface.GetAll();
                return Ok(response);
            }
            catch (NotImplementedException errorCreateBrand)
            {
                switch (errorCreateBrand.Message)
                {
                
                    default:
                        return BadRequest(errorCreateBrand.Message);
                }
                throw;
            }
        }
    }
}
