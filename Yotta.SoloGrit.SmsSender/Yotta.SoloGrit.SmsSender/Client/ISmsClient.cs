using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yotta.SoloGrit.SmsSender.Requests;
using Yotta.SoloGrit.SmsSender.Responses;

namespace Yotta.SoloGrit.SmsSender.Client
{
    public interface ISmsClient
    {
        Task<IEnumerable<SendSmsResponse>> SendSms(SendSmsRequest sendSmsRequest, Action<SendSmsErrorResponse> error);
    }
}