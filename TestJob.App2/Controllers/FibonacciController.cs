using Microsoft.AspNetCore.Mvc;
using TestJob.Messages;
using TestJob.Messaging;

namespace TestJob.App2.Controllers
{
    [Route("api/[controller]")]
    public class FibonacciController : Controller
    {
        private readonly IMessageHandler<NextFibonacciMessage> _messageHandler;

        public FibonacciController(IMessageHandler<NextFibonacciMessage> messageHandler)
        {
            _messageHandler = messageHandler;
        }

        [HttpPost]
        public void Post([FromBody]NextFibonacciMessage value)
        {                        
            _messageHandler.Handle(value);
        }        
    }
}
