using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tekton.Application.Features.Products.Commands.CreateProduct;
using Tekton.Application.Features.Products.Commands.UpdateProduct;
using Tekton.Application.Features.Products.Queries.GetProduct;
using Tekton.Dominio;

namespace Tekton.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Product Controller
        /// </summary>
        /// <param name="mediator"></param>
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene un producto con el código específico
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        [HttpGet("{productid}", Name = "GetProduct")] 
        [ProducesResponseType(typeof(ProductDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductDTO>> GetProductById(int productid)
        {
            var query = new GetProductQuery(productid);
            var product = await _mediator.Send(query);
            return Ok(product);
        }

        /// <summary>
        /// Realiza el registro de un producto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateProduct")] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateProduct([FromBody] CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Realiza la actualizaicón de un producto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
