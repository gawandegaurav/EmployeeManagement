using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Utilities
{
    public class ValidEmailDomain : ValidationAttribute
    {
        private readonly string _allowedDomain;

        public ValidEmailDomain(string allowedDomain)
        {
            _allowedDomain = allowedDomain;
        }

        public override bool IsValid(object value)
        {
            //test@test.com-> [test, test.com]
            var domainPart = value.ToString().Split('@')[1];
            return domainPart.ToUpper() == _allowedDomain.ToUpper();
        }
    }
}