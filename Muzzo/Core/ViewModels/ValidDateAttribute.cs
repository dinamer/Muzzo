using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Muzzo.Core.ViewModels
{
    public class ValidDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;

            var isValid = DateTime.TryParseExact(Convert.ToString(value), "dd.MM.yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTime);

            return (isValid && dateTime > DateTime.Now); 
        }

    }
}