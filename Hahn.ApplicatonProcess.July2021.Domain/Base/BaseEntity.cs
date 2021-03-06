namespace Hahn.ApplicatonProcess.July2021.Domain.Base
{
    public abstract class BaseEntity
    {
        //private List<BaseDomainEvent> _events = new List<BaseDomainEvent>();
        //public IReadOnlyList<BaseDomainEvent> Events => _events.AsReadOnly();

        //protected void AddEvent(BaseDomainEvent @event)
        //{
        //    _events.Add(@event);
        //}

        //protected void RemoveEvent(BaseDomainEvent @event)
        //{
        //    _events.Remove(@event);
        //}
    }

    public abstract class BaseEntity<TKey> : BaseEntity
    {
        public TKey Id { get; set; }
    }
}
