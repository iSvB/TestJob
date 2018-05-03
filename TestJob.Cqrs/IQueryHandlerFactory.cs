namespace TestJob.Cqrs
{
    public interface IQueryHandlerFactory
    {
        IQueryHandler<TDefinition, TResult> CreateQueryHandler<TDefinition, TResult>()
            where TDefinition : class, IQueryDefinition<TResult>
            where TResult : class, IQueryResult;
    }
}