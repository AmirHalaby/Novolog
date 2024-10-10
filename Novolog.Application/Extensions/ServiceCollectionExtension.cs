using Microsoft.Extensions.DependencyInjection;
using Novolog.Application.BL.DisplayDoctors;
using Novolog.Application.Services.DisplayDoctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novolog.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IDisplayDoctorsService, DisplayDoctorsService>();
            services.AddScoped<IDisplayDoctorsBL, DisplayDoctorsBL>();

        }
    }
}
