using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Exceptions
{
    public class ValidationExcepion : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationExcepion() : base("One or more validation failures have ocurred")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationExcepion(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

    }
}
