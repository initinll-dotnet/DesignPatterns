﻿namespace Facade;

/// <summary>
/// Subsystem class
/// </summary>
public class OrderService
{
    public bool HasEnoughOrders(int customerId)
    {
        // does the customer have enough orders?  
        // fake calculation for demo purposes
        return (customerId > 5);
    }
}

/// <summary>
/// Subsystem class
/// </summary>
public class CustomerDiscountBaseService
{
    public double CalculateDiscountBase(int customerId)
    {
        // fake calculation for demo purposes
        return (customerId > 8) ? 10 : 20;
    }
}

/// <summary>
/// Subsystem class
/// </summary>
public class DayOfTheWeekFactorService
{
    public double CalculateDayOfTheWeekFactor()
    {
        // fake calculation for demo purposes
        return DateTime.UtcNow.DayOfWeek switch
        {
            DayOfWeek.Saturday or DayOfWeek.Sunday => 0.8,
            _ => 1.2,
        };
    }
}

/// <summary>
/// Facade
/// </summary>
public class DiscountFacade
{
    private readonly OrderService _orderService;
    private readonly CustomerDiscountBaseService _customerDiscountBaseService;
    private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService;

    public DiscountFacade(
        OrderService orderService,
        CustomerDiscountBaseService customerDiscountBaseService,
        DayOfTheWeekFactorService dayOfTheWeekFactorService)
    {
        _orderService = orderService;
        _customerDiscountBaseService = customerDiscountBaseService;
        _dayOfTheWeekFactorService = dayOfTheWeekFactorService;
    }

    public double CalculateDiscountPercentage(int customerId)
    {
        if (!_orderService.HasEnoughOrders(customerId))
        {
            return 0;
        }

        return _customerDiscountBaseService.CalculateDiscountBase(customerId)
            * _dayOfTheWeekFactorService.CalculateDayOfTheWeekFactor();
    }
}