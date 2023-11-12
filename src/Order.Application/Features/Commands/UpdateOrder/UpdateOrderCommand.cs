using MediatR;
using Order.Application.Features.Commands.CheckoutOrder;

namespace Order.Application.Features.Commands.UpdateOrder
{
    public class UpdateOrderCommand : CheckoutOrderCommand, IRequest
    {
        public int Id { get; set; }
    }
}
