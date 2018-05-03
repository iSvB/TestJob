namespace TestJob.Cqrs
{
    public interface IQueryDispatcher
    {
        TResult Dispatch<TDefinition, TResult>(TDefinition queryDefinition)
            where TDefinition : class, IQueryDefinition<TResult>
            where TResult : class, IQueryResult;
    }
}