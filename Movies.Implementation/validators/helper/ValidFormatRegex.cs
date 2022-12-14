using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Movies.Implementation.validators.helper
{
    public static class ValidFormatRegex
    {
        public static string ValidNameFormat => @"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$";
        public static string ValidUsernameFormat => @"^(?=[a-zA-Z0-9._]{3,12}$)(?!.*[_.]{2})[^_.].*[^_.]$";
        public static string ValidPasswordFormat => @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

    }

    public static class ValidationMessages
    {
        public static string IsRequired(string m) => $"{m} is required";  
        public static string InvalidFormat(string m) => $" Invalid format for {m}";

        public static string EntityNotInDatabase(string m) => $"Entity {m} doesn't exist in database";
        public static string CorrectPasswordFormat  => @"The password must contain a minimum of 8 characters, 
                                                         one uppercase letter, one lowercase letter, a number 
                                                         and a special character.";       
    }   
}
