using Rebus.Bus;
using Thunders.TechTest.Domain.Pedagios.Dtos;

namespace Thunders.TechTest.OutOfBox.Queues
{
    public class RebusMessageSender(IBus bus) : IMessageSender
    {
        public virtual async Task SendLocal(object message)
        {
            await bus.SendLocal(message).ConfigureAwait(false);
        }
        
        public virtual async Task Publish(object message)
        {
            await bus.Publish(message).ConfigureAwait(false);
        }
    }
}