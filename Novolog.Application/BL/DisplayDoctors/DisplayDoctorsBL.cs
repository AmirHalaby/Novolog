using Microsoft.Extensions.Logging;
using Novolog.Application.Dtos;
using Novolog.Application.Services.DisplayDoctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SqlTypes;
using System.Numerics;

namespace Novolog.Application.BL.DisplayDoctors
{
    internal class DisplayDoctorsBL: IDisplayDoctorsBL
    {
        private readonly ILogger<DisplayDoctorsBL> _logger;

        IEnumerable<DoctorsDto> doctors = new List<DoctorsDto>();

        Dictionary<string, Dictionary<string, string>> languages =
           new Dictionary<string, Dictionary<string, string>>();

        public DisplayDoctorsBL(ILogger<DisplayDoctorsBL> logger)
        {
            _logger = logger;
        }
        public IList<ResponseDisplayDoctors> GetDoctorsList()
        {
            IList<ResponseDisplayDoctors> responseDisplayDoctors = new List<ResponseDisplayDoctors>();
            try
            {
                _logger.LogInformation("GetDoctorsListBL Start");

                // Get only active doctors from json file with descending OrderBy serviceRate,totalRatings and then OrderBy promotionLevel.
                GetDoctorsFromJsonFile();
                _logger.LogInformation("GetDoctorsFromJsonFile success");

                // Get languages from Json file and save them in languages dictionary
                GetLanguagesFromJsonFile();
                _logger.LogInformation("GetLanguagesFromJsonFile success");

                foreach (var doctor in doctors)
                {
                     responseDisplayDoctors.Add(
                         new ResponseDisplayDoctors(
                             doctor.fullName, // FullName 
                            //  Handle Phone vlidation Phone number must be with format xx-xxxxxxx or xxx-xxxxxxx
                             PhoneValidation(doctor.phones.FirstOrDefault().number), // PhoneNumber                       
                             GetlanguageName(doctor.languageIds), // LanguagesName
                             doctor.reviews.serviceRate // ServiceRate
                             )
                         );                    
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            _logger.LogInformation("GetDoctorsListBL Finish");
            return responseDisplayDoctors;
        }

        
        public List<string> GetlanguageName(List<string> languageIds)
        {
            List<string> result = new List<string>();
            foreach (var language in languageIds)
            {
                if(languages["language"].ContainsKey(language))
                    result.Add(languages["language"][language]);
            }
            return result;
        }
        // Phone Heandle: must be with Format xxx-xxxxxxx or xx-xxxxxxx
        public string PhoneValidation(string phoneNumber)
        {
            if (!phoneNumber.Contains('-'))
            {
                if (phoneNumber.Length == 10)
                {
                    return phoneNumber.Substring(0, 3) + "-" + phoneNumber.Substring(3, 7);
                }
                else if (phoneNumber.Length == 9)
                {
                    return  phoneNumber.Substring(0, 2) + "-" + phoneNumber.Substring(2, 7);

                }
            }
            return phoneNumber;           
        }

        public void GetDoctorsFromJsonFile()
        {
            using StreamReader doctorsReader = new("C:\\Novolog task\\doctors.json");
            var json = doctorsReader.ReadToEnd();

            doctors = JsonConvert.DeserializeObject<List<DoctorsDto>>(json)
                .Where(x => x.isActive == true && x.promotionLevel <= 5)
                .OrderByDescending(p => p.reviews.serviceRate)
                .ThenByDescending(p => p.reviews.totalRatings)
                .ThenBy(p => p.promotionLevel);
        }

        public void GetLanguagesFromJsonFile()
        {
            using StreamReader languagesReader = new("C:\\Novolog task\\language.json");
            var languagesjson = languagesReader.ReadToEnd();
            languages = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(languagesjson);
        }
    }
}
// Insert languageId to HashSet
//foreach (var languageId in doctor.languageIds)
//{
//    languageIds.Add(languageId);
//}
// languages = JsonConvert.DeserializeObject<Dictionary<string, string>>(languagesjson);
