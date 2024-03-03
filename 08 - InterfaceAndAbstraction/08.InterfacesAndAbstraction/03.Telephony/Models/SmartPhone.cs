

using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class SmartPhone : IPhones, IWideWeb
    {
        public string Call(string phoneNumber)
        {
            bool isNumberValid = CheckNumber(phoneNumber);
            if (isNumberValid)
            {
                return "Invalid number!";

            }
            return $"Calling... {phoneNumber}";
        }


        public string Browse(string url)
        {
            bool isUrlValid = CheckUrl(url);
            if (isUrlValid) 
            {
                return "Invalid URL!";
            }
            return $"Browsing: {url}!";
        }

        private bool CheckNumber(string phoneNumber)
        {
            return phoneNumber.Any(p => !char.IsNumber(p));
        }
       
        private bool CheckUrl(string url)
        {
            return url.Any(c => char.IsDigit(c));
        }
    }
}
