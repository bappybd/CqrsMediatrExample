using MediatR;
using WebApplicationProject.models;

namespace WebApplicationProject.Notifications
{
    public record ProductAddedNotification(Product Product): INotification;
}
