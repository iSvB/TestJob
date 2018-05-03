using SimpleInjector;
using TestJob.Cqrs;

namespace TestJob.Composition
{
    public sealed class QueryHandlerFactory : IQueryHandlerFactory
    {
        private readonly Container _container;

        public QueryHandlerFactory(Container container)
        {
            _container = container;
        }

        public IQueryHandler<TDefinition, TResult> CreateQueryHandler<TDefinition, TResult>()        
            where TDefinition : class, IQueryDefinition<TResult>
            where TResult : class, IQueryResult
        {
            return _container.GetInstance<IQueryHandler<TDefinition, TResult>>();
        }         
    }
}