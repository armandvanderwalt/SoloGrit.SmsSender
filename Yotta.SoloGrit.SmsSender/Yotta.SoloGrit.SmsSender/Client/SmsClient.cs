using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Yotta.SoloGrit.SmsSender.Exceptions;
using Yotta.SoloGrit.SmsSender.Requests;
using Yotta.SoloGrit.SmsSender.Responses;

namespace Yotta.SoloGrit.SmsSender.Client
{
    public class SmsClient : ISmsClient
    {
        private readonly HttpClient _httpClient;

        public SmsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SendSmsResponse>> SendSms(SendSmsRequest sendSmsRequest, Action<SendSmsErrorResponse> error)
        {
            var url = "api/Message/Send";

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                var jsonData = JsonConvert.SerializeObject(sendSmsRequest);
                var content = new StringContent(jsonData);
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                request.Content = content;

                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                var response = await _httpClient.SendAsync(request);

                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        var responseJson = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<SendSmsResponse>>(responseJson);
                    case System.Net.HttpStatusCode.BadRequest:
                        var errorResponseJson = await response.Content.ReadAsStringAsync();
                        error?.Invoke(JsonConvert.DeserializeObject<SendSmsErrorResponse>(errorResponseJson));
                        return null;
                    default:
                        throw new SoloGritSmsSenderException("Invalid SMS Request");
                }
            }

        }
    }
}
