using Novolog.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novolog.Application.BL.DisplayDoctors
{
    public interface IDisplayDoctorsBL
    {
        public IList<ResponseDisplayDoctors> GetDoctorsList();
    }
}
