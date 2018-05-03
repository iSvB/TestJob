namespace TestJob.Cqrs
{
    public sealed class QueryDispatcher : IQueryDispatcher
    {
        private readonly IQueryHandlerFactory _queryHandlerFactory;

        public QueryDispatcher(IQueryHandlerFactory queryHandlerFactory)
        {
            _queryHandlerFactory = queryHandlerFactory;
        }
        
        public TResult Dispatch<TDefinition, TResult>(TDefinition queryDefinition) 
            where TDefinition : class, IQueryDefinition<TResult> 
            where TResult : class, IQueryResult
        {
            var handler = _queryHandlerFactory.CreateQueryHandler<TDefinition, TResult>();
            return handler.Handle(queryDefinition);
        }
    }
}