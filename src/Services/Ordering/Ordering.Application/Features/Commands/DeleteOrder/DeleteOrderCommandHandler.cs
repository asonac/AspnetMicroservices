using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderReporsitory;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public DeleteOrderCommandHandler(IOrderRepository orderReporsitory, IMapper mapper, ILogger<DeleteOrderCommandHandler> logger)
        {
            _orderReporsitory = orderReporsitory;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _orderReporsitory.GetByIdAsync(request.Id);

            if (orderToDelete == null)
            {
                _logger.LogError("Order does not exist on database");
                throw new NotFoundException(nameof(Order), request.Id);
            }
            await _orderReporsitory.DeleteAsync(orderToDelete);

            return Unit.Value;
        }
    }
}
