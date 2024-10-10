using Novolog.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novolog.Application.Services.DisplayDoctors
{
    public interface IDisplayDoctorsService
    {
        public IList<ResponseDisplayDoctors> GetDoctorsList();
    }
}

