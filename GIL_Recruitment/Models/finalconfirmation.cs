using Google.Protobuf.WellKnownTypes;
using System.Security.Cryptography.Xml;

namespace GIL_Recruitment.Models
{
    public class finalconfirmation
    {
        public personal_infomodel PersonalInfo { get; set; }

        public GraduationInfo Education { get; set; }

        public professional professional { get; set; }

    }
}
