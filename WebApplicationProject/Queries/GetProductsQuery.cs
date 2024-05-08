using MediatR;
using WebApplicationProject.models;

namespace WebApplicationProject.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
}
