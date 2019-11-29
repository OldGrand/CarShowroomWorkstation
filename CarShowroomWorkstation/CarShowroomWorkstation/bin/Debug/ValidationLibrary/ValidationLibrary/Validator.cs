using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ValidationLibrary
{
    public static class Validator
    {
        const string _phoneRegexPattern = @"^([+]?375\d{2})?((\d{3}[-]{1}\d{2}[-]{1}\d{2})|(\d{3}[ ]{1}\d{2}[ ]{1}\d{2})|(\d{3}\d{2}\d{2}))\b$";
        const string _passportRegexPattern = @"^[A-Z]{2}\d{6}$";
        const string _emailRegexPattern = @"^(([^<>()\[\]\\.,;:\s@]+(\.[^<>()\[\]\\.,;:\s@]+)*)|(.+))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";

        public static bool PassportNumValidation(string value) => new Regex(_passportRegexPattern).IsMatch(value);

        public static bool PhoneNumberValidation(string value) => new Regex(_phoneRegexPattern).IsMatch(value);

        public static bool EmailValidation(string value) => new Regex(_emailRegexPattern).IsMatch(value);

        public static bool PhoneNumbersValidationRange(List<string> values)
        {
            Regex regex = new Regex(_phoneRegexPattern);
            foreach (string value in values)
            {
                if (!regex.IsMatch(value))
                    return false;
            }
            return true;
        }

        public static bool PassportNumValidationRange(List<string> values)
        {
            Regex regex = new Regex(_passportRegexPattern);
            foreach (string value in values)
            {
                if (!regex.IsMatch(value))
                    return false;
            }
            return true;
        }
    }
}
