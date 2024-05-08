using MediatR;
using WebApplicationProject.Commands;
using WebApplicationProject.models;
using WebApplicationProject.Services;

namespace WebApplicationProject.Handlers
{
    public class AddProductHandler: IRequestHandler<AddProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public AddProductHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task<Product> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddProduct(command.Product);
            return command.Product;
        }
    }
}
