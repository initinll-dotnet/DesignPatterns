using EnterprisePatterns.Entities;
using EnterprisePatterns.UnitsOfWork;

namespace EnterprisePatterns.DemoServices;

public class UnitOfWorkDemoService
{
    private readonly CreateOrderWithOrderLinesUnitOfWork _unitOfWork;

    public UnitOfWorkDemoService(CreateOrderWithOrderLinesUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task RunAsync()
    {
        // create an order
        Order orderToAdd = new Order("My new order");
        _unitOfWork.OrderRepository.Add(orderToAdd);

        // create an order line
        OrderLine orderLineToAdd = new OrderLine("A product I bought", 1)
        { Order = orderToAdd };
        _unitOfWork.OrderLineRepository.Add(orderLineToAdd);

        // persist the changes 
        await _unitOfWork.CommitAsync();
    }
}
