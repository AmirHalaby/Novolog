using Microsoft.Extensions.Logging;
using Novolog.Application.BL.DisplayDoctors;
using Novolog.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novolog.Application.Services.DisplayDoctors
{
    internal class DisplayDoctorsService : IDisplayDoctorsService
    {
        private readonly ILogger<DisplayDoctorsService> _logger;
        private readonly IDisplayDoctorsBL _displayDoctorsBL;

        public DisplayDoctorsService( ILogger<DisplayDoctorsService> logger, IDisplayDoctorsBL displayDoctorsBL)
        {
            _logger = logger;
            _displayDoctorsBL = displayDoctorsBL;
        }

        public IList<ResponseDisplayDoctors> GetDoctorsList()
        {
            return _displayDoctorsBL.GetDoctorsList();
        }
    }
}
