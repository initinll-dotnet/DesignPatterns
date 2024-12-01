namespace State;

/// <summary>
/// State
/// </summary>
public abstract class BankAccountState
{
    public BankAccount BankAccount { get; protected set; } = null!;
    public decimal Balance { get; protected set; }

    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);

}

/// <summary>
/// ConcreteState
/// </summary>
public class GoldState : BankAccountState
{
    public GoldState(decimal balance, BankAccount bankAccount)
    {
        base.Balance = balance;
        base.BankAccount = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing " +
            $"{amount} + 10% bonus: {amount / 10}");

        base.Balance += amount + (amount / 10);
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, withdrawing {amount} from {base.Balance}");

        // change state to overdrawn when withdrawing results in less than zero
        base.Balance -= amount;

        if (base.Balance < 1000 && base.Balance >= 0)
        {
            // change state to regular
            base.BankAccount.BankAccountState = new RegularState(balance: base.Balance, bankAccount: base.BankAccount);
        }
        else if (base.Balance < 0)
        {
            // change state to overdrawn
            base.BankAccount.BankAccountState = new OverdrawnState(balance: base.Balance, bankAccount: base.BankAccount);
        }
    }
}

/// <summary>
/// ConcreteState
/// </summary>
public class RegularState : BankAccountState
{
    public RegularState(decimal balance, BankAccount bankAccount)
    {
        base.Balance = balance;
        base.BankAccount = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing {amount}");

        base.Balance += amount;

        if (base.Balance >= 1000)
        {
            // change state to gold
            base.BankAccount.BankAccountState = new GoldState(balance: base.Balance, bankAccount: base.BankAccount);
        }
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, withdrawing {amount} from {base.Balance}");

        // change state to overdrawn when withdrawing results in less than zero
        base.Balance -= amount;

        if (base.Balance < 0)
        {
            // change state to overdrawn
            base.BankAccount.BankAccountState = new OverdrawnState(balance: base.Balance, bankAccount: base.BankAccount);
        }
    }
}

/// <summary>
/// ConcreteState
/// </summary>
public class OverdrawnState : BankAccountState
{
    public OverdrawnState(decimal balance, BankAccount bankAccount)
    {
        base.Balance = balance;
        base.BankAccount = bankAccount;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"In {GetType()}, depositing {amount}");

        base.Balance += amount;

        if (base.Balance >= 0)
        {
            // change state to regular
            base.BankAccount.BankAccountState = new RegularState(balance: base.Balance, bankAccount: base.BankAccount);
        }
    }

    public override void Withdraw(decimal amount)
    {
        // cannot withdraw
        Console.WriteLine($"In {GetType()}, cannot withdraw, balance {base.Balance}");
    }
}


/// <summary>
/// Context
/// </summary>
public class BankAccount
{
    public BankAccountState BankAccountState { get; set; }

    public decimal Balance
    {
        get
        {
            return BankAccountState.Balance;
        }
    }

    public BankAccount()
    {
        BankAccountState = new RegularState(balance: 200, bankAccount: this);
    }

    /// <summary>
    /// Request a deposit
    /// </summary> 
    public void Deposit(decimal amount)
    {
        // let the current state handle the deposit
        BankAccountState.Deposit(amount);
    }

    /// <summary>
    /// Request a withdrawal
    /// </summary> 
    public void Withdraw(decimal amount)
    {
        // let the current state handle the withdrawel
        BankAccountState.Withdraw(amount);
    }
}