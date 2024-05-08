using MediatR;
using WebApplicationProject.models;

namespace WebApplicationProject.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
