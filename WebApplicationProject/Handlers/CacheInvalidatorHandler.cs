using MediatR;
using WebApplicationProject.models;
using WebApplicationProject.Notifications;
using WebApplicationProject.Services;

namespace WebApplicationProject.Handlers
{
    public class CacheInvalidatorHandler: INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;

        public CacheInvalidatorHandler(FakeDataStore fakeDataStore)
        {
            this._fakeDataStore = fakeDataStore;
        }

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.Product, "Cache Invalidated");
            await Task.CompletedTask;
        }
    }
}
