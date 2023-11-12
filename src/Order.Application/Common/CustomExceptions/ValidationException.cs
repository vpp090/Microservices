using FluentValidation.Results;

namespace Order.Application.Common.CustomExceptions
{
    public class CustomValidationException : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; set; }

        public CustomValidationException() 
            :base("ValidationRules_Conflict")
        {
             Errors = new Dictionary<string, string[]>();
        }

        public CustomValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(fg => fg.Key, fg => fg.ToArray());
        }
    }
}
