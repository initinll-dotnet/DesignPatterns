namespace Bridge;

/// <summary>
/// Abstraction
/// </summary>
public abstract class Menu
{
    protected Menu(ICoupon coupon)
    {
        Coupon = coupon;
    }

    public readonly ICoupon Coupon;
    public abstract int CalculatePrice();
}

/// <summary>
/// RefinedAbstraction
/// </summary>
public class VegetarianMenu : Menu
{
    public VegetarianMenu(ICoupon coupon) : base(coupon)
    {
    }
    public override int CalculatePrice()
    {
        return 20 - Coupon.CouponValue;
    }
}

/// <summary>
/// RefinedAbstraction
/// </summary>
public class MeatBasedMenu: Menu
{
    public MeatBasedMenu(ICoupon coupon) : base(coupon)
    {        
    }
    public override int CalculatePrice()
    {
        return 30 - Coupon.CouponValue;
    }
}

/// <summary>
/// Implementor
/// </summary>
public interface ICoupon
{
    int CouponValue { get; }
}

/// <summary>
/// ConcreteImplementor
/// </summary>
public class NoCoupon : ICoupon
{
    public int CouponValue { get => 0; }
}

/// <summary>
/// ConcreteImplementor
/// </summary>
public class OneEuroCoupon : ICoupon
{
    public int CouponValue { get => 1; }
}

/// <summary>
/// ConcreteImplementor
/// </summary>
public class TwoEuroCoupon : ICoupon
{
    public int CouponValue { get => 2; }
}
