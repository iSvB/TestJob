using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using TestJob.Messages;
using TestJob.Settings;

namespace TestJob.Messaging.Http
{
    public sealed class HttpPublishMessageBroker : IPublishMessageBroker
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        
        public void Publish<T>(T message) where T : class, IMessage
        {
            var json = JsonConvert.SerializeObject(message);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var uri = MessageBrokerSettings.GetUri<T>();
            _httpClient.PostAsync(uri, content);
        }
    }
}