using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = Ordering.Application.Exceptions.ValidationExcepion;

namespace Ordering.Application.Behaviours
{
    public class ValidationBehaviour<TRquest, TResponse> : IPipelineBehavior<TRquest, TResponse>
    {
        private readonly IEnumerable<IValidator<TRquest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRquest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRquest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRquest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
