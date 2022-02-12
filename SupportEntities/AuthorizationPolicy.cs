using System.Collections.Generic;

namespace MemAthleteServer.SupportEntities
{
    public class AuthorizationPolicy
    {
        public string PayloadKey { get; set; }
        public List<string> QualificationValues { get; set; }
    }
}