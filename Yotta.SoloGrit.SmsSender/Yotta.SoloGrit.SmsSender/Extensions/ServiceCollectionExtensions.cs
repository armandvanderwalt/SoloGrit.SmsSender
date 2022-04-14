using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Yotta.SoloGrit.SmsSender.Client;

namespace Yotta.SoloGrit.SmsSender.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSoloGritSmsSender(this IServiceCollection service, string apiKey, Uri baseUri = null)
        {
            var clientName = "SoloGrit.SmsClient";
            service.AddHttpClient(clientName);
            service.AddTransient<ISmsClient>(s =>
            {
                var httpClientFactory = s.GetRequiredService<IHttpClientFactory>();

                var httpClient = httpClientFactory.CreateClient(clientName);

                httpClient.BaseAddress = baseUri ?? new Uri("https://sms.sologrit.co.za");
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", apiKey);

                return new SmsClient(httpClient);
            });
        }
    }
}
