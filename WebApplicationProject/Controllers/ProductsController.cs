using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationProject.Commands;
using WebApplicationProject.models;
using WebApplicationProject.Notifications;
using WebApplicationProject.Queries;

namespace WebApplicationProject.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());

            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody]Product product)
        {
            var productToReturn = await _mediator.Send(new AddProductCommand(product));
            await _mediator.Publish(new ProductAddedNotification(productToReturn));

            return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpGet("{id:int}", Name ="GetProductById")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }
    }
}
