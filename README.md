# SoloGrit SMS Sender

![Nuget](https://img.shields.io/nuget/v/Yotta.SoloGrit.SmsSender?style=for-the-badge)

## Usage

```
PM> Install-Package Yotta.SoloGrit.SmsSender
```

```c#
services.AddSoloGritSmsSender("API_KEY");


var sms = new SendSmsRequest
{
    Content = "Message Goes Here",
    To = new List<string>
    {
        msisdn
    },
    ReportingHierarchyId = 1
};

var errorMessages = default(SendSmsErrorResponse);
var smsResult = await _smsClient.SendSms(sms, errors => errorMessages = errors);

```