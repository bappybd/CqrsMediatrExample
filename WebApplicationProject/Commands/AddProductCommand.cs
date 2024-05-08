using MediatR;
using WebApplicationProject.models;

namespace WebApplicationProject.Commands
{
    public record AddProductCommand(Product Product): IRequest<Product>;
}
