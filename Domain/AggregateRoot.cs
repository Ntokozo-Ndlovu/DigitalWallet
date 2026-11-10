using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class AggregateRoot
    {
       private readonly List<DomainEvent> _domainEvents = new();
       public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();
      
       protected void RaiseDomainEvent(DomainEvent domainEvent)=> _domainEvents.Add(domainEvent);
         

        public void ClearDomainEvents() => _domainEvents.Clear();
        
        //It has Domain Events
      //We need to read and add events

    }
}
