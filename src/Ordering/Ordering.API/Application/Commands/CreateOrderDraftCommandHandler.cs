﻿namespace Ordering.API.Application.Commands;

// Regular CommandHandler
public class CreateOrderDraftCommandHandler : IRequestHandler<CreateOrderDraftCommand, OrderDraftDto>
{
    // private readonly IOrderRepository _orderRepository;
    // private readonly IIdentityService _identityService;
    // private readonly IMediator _mediator;

    // Using DI to inject infrastructure persistence Repositories
    public CreateOrderDraftCommandHandler() //  IMediator mediator, IIdentityService identityService
    {
        // _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        // _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public Task<OrderDraftDto> Handle(CreateOrderDraftCommand message, CancellationToken cancellationToken)
    {
        var order = Ordering.Domain.AggregatesModel.Order.NewDraft();
        var orderItems = message.Items.Select(i => i.ToOrderItemDTO());
        foreach (var item in orderItems)
        {
            order.AddOrderItem(item.ProductId, item.ProductName, item.UnitPrice, item.Discount, item.PictureUrl, item.Units);
        }

        return Task.FromResult(OrderDraftDto.FromOrder(order));
    }
}

public class OrderDraftDto
{
    public IEnumerable<OrderItemDTO>? OrderItems { get; set; }
    public decimal Total { get; set; }

    public static OrderDraftDto FromOrder(Ordering.Domain.AggregatesModel.Order order)
    {
        return new OrderDraftDto()
        {
            OrderItems = order.OrderItems.Select(oi => new OrderItemDTO
            {
                Discount = oi.GetCurrentDiscount(),
                ProductId = oi.ProductId,
                UnitPrice = oi.GetUnitPrice(),
                PictureUrl = oi.GetPictureUri(),
                Units = oi.GetUnits(),
                ProductName = oi.GetOrderItemProductName()
            }),
            Total = order.GetTotal()
        };
    }
}
