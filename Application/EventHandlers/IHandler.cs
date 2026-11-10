namespace Application.EventHandlers
{
    public interface IHandler<T>
   {
     public Task  HandleAsync(CancellationToken t, T domainEvent);
    }
}
