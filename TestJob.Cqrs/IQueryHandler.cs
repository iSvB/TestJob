namespace TestJob.Cqrs
{
    public interface IQueryHandler<in TDefinition, out TResult>
        where TDefinition : class, IQueryDefinition<TResult>
        where TResult : class, IQueryResult
    {
        TResult Handle(TDefinition queryDefinition);
    }
}