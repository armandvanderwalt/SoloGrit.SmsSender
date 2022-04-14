using System.Collections.Generic;

namespace Yotta.SoloGrit.SmsSender.Requests
{
    public class SendSmsRequest
    {
        public string From { get; set; }
        public List<string> To { get; set; }
        public string Content { get; set; }
        public int ReportingHierarchyId { get; set; }
        public List<ReportingKeys> ReportingAttributes { get; set; }
    }
}
