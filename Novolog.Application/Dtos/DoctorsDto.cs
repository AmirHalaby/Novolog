using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novolog.Application.Dtos
{
    public class DoctorsDto
    {
        public int id { get; set; }
        public int promotionLevel { get; set; }
        public List<string> languageIds { get; set; } = new List<string>();
        public string fullName { get; set; } = string.Empty;
        public bool isActive { get; set; }
        public ReviewsDto reviews { get; set; } = new ReviewsDto();
        public IEnumerable<PhonesDto> phones { get; set; } = Enumerable.Empty<PhonesDto>();
    }
}
