using Thunders.TechTest.Domain.Pedagios.Dtos;

namespace Thunders.TechTest.OutOfBox.Queues;

public interface IMessageSender
{
    Task SendLocal(PedagioDto message);
    Task Publish(PedagioDto message);
}
