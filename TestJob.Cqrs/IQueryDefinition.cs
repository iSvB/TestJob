namespace TestJob.Cqrs
{
    public interface IQueryDefinition<T> where T : class, IQueryResult
    {
    }
}