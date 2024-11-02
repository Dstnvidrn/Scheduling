using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Services
{
    internal class LocalizationService
    {
        private static ResourceManager _resourceManager;

        static LocalizationService()
        {
            SetCulture("en");
        }

        public static void SetCulture(string cultureCode) 
        { 
            CultureInfo culture = new CultureInfo(cultureCode);
            _resourceManager = new ResourceManager("Scheduling.Resources.Localization.Messages.en.resx", typeof(LocalizationService).Assembly);
            CultureInfo.CurrentUICulture = culture;
        }
        public static string GetMessage(string key)
        {
            return _resourceManager.GetString(key, CultureInfo.CurrentUICulture);
        }

    }
}
