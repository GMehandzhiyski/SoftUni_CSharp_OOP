using System;
using System.Collections.Generic;
using System.Linq;
using Telephony.Models.Interfaces;



namespace Telephony.Models
{
    public class StationaryPhone : IPhones
    {
        public string Call(string phoneNumber)
        {
            bool isNumberValid = CheckNumber(phoneNumber);
            if (isNumberValid)
            {
                return $"Invalid number!";
            }
            return $"Dialing... {phoneNumber}";
        }

        private bool CheckNumber(string phoneNumber)
        {
           return phoneNumber.Any(p => !char.IsDigit(p));
        }
    }
}
