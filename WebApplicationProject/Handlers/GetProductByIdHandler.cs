using MediatR;
using WebApplicationProject.models;
using WebApplicationProject.Queries;
using WebApplicationProject.Services;

namespace WebApplicationProject.Handlers
{
    public class GetProductByIdHandler: IRequestHandler<GetProductByIdQuery, Product>
    {
        private FakeDataStore _fakeDataStore;

        public GetProductByIdHandler(FakeDataStore fakeDataStore)
        {
               _fakeDataStore = fakeDataStore;
        }

        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetProductById(query.Id);
        }
    }
}
