﻿using Thunders.TechTest.Domain.Pedagios.Dtos;

namespace Thunders.TechTest.OutOfBox.Queues;

public interface IMessageSender
{
    Task SendLocal(object message);
    Task Publish(object message);
}
