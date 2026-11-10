using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Application
{
    public interface IEventDispatcher
    {
        public Task DispatchDomainEvents(List<DomainEvent> domainEvents);
    }
}
