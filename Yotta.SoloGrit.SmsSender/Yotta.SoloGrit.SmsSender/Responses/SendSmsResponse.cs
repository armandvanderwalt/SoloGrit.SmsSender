namespace Yotta.SoloGrit.SmsSender.Responses
{
    public class SendSmsResponse
    {
        public long MessageId { get; set; }
        public string ExternalId { get; set; }
        public string Provider { get; set; }
    }
}
