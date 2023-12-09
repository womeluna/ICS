class Receiver
{
    // банковские переводы
    public bool BankTransfer { get; set; }
    // денежные переводы - WesternUnion, Unistream
    public bool MoneyTransfer { get; set; }
    // перевод через PayPal
    public bool PayPalTransfer { get; set; }
    public Receiver(bool bt, bool mt, bool ppt)
    {
        BankTransfer = bt;
        MoneyTransfer = mt;
        PayPalTransfer = ppt;
    }
}
abstract class PaymentHandler
{
    public PaymentHandler Successor { get; set; }
    public abstract void Handle(Receiver receiver);
}
class BankPaymentHandler : PaymentHandler
{
    public override void Handle(Receiver receiver)
    {
        if (receiver.BankTransfer == true)
            Console.WriteLine("Выполняем банковский перевод");
        else if (Successor != null)
            Successor.Handle(receiver);
    }
}
class MoneyPaymentHandler : PaymentHandler
{
    public override void Handle(Receiver receiver)
    {
        if (receiver.MoneyTransfer == true)
            Console.WriteLine("Выполняем перевод через системы денежных переводов");
        else if (Successor != null)
            Successor.Handle(receiver);
    }
}
class PayPalHandler : PaymentHandler
{
    public override void Handle(Receiver receiver)
    {
        if (receiver.PayPalTransfer == true)
            Console.WriteLine("Выполняем перевод через PayPal");
        else if (Successor != null)
            Successor.Handle(receiver);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Receiver receiver = new Receiver(true, false, false);
        PaymentHandler bankPaymentHandler = new BankPaymentHandler();
        PaymentHandler moneyPaymentHnadler = new MoneyPaymentHandler();
        PaymentHandler paypalPaymentHandler = new PayPalHandler();
        bankPaymentHandler.Successor = paypalPaymentHandler;
        paypalPaymentHandler.Successor = moneyPaymentHnadler;
        bankPaymentHandler.Handle(receiver);

    }
}

/* Поскольку в примере ресивер имеет свойства true для перевода через PayPal и систему денежных переводов,
 * при изменении порядка объектов-обработчиков результатом будет перевод через одну из двух систем (той,
 * обработчик которой стоит раньше).
 * В зависимости от начальных параметров мы можем получить различные результаты.
 * 
 * Мы используем паттерн, когда программа должна обрабатывать разнообразные запросы несколькими способами,
 * но заранее неизвестно, какие конкретно запросы будут приходить и какие обработчики для них понадобятся.
 */