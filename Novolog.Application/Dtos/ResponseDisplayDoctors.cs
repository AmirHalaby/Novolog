using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novolog.Application.Dtos
{
    public class ResponseDisplayDoctors
    {
        public string FullName { get; set; } = string.Empty;
        public string PhoneName { get; set; } = string.Empty;
        public IList<string> LanguagesId { get; set; } = new List<string>();
        public int ServiceRate { get; set; }

        public ResponseDisplayDoctors(string fullName, string phoneName, List<string> languagesId, int serviceRate)
        {
            FullName = fullName;
            PhoneName = phoneName;
            LanguagesId = languagesId;
            ServiceRate = serviceRate;
        }       
    }
}
