abstract class TransportService
{
    public string Name { get; set; }
    public TransportService(string name)
    {
        Name = name;
    }
    abstract public double CostTransportation(double distance);
}
abstract class TransportCompany
{
    public string Name { get; set; }
    public TransportCompany(string n)
    {
        Name = n;
    }
    public override string ToString()
    {
        return Name;
    }
    // фабричный метод, ответственный за создание экземпляра TransportService.
    abstract public TransportService Create(string n, int k);
}
class TaxiServices : TransportService
{
    public int Category { get; set; }
    public TaxiServices(string name, int cat) :
    base(name)
    {
        Category = cat;
    }
    public override double CostTransportation(double distance)
    {
        return distance * Category;
    }
    public override string ToString()
    {
        string s = String.Format("Фирма {0}, поездка категории {1}",
        Name, Category);
        return s;
    }
}
class Shipping : TransportService
{
    public double Tariff { get; set; }
    public Shipping(string name, int taff) :
    base(name)
    {
        Tariff = taff;
    }
    public override double CostTransportation(double distance)
    {
        return distance * Tariff;
    }
    public override string ToString()
    {
        string s = String.Format("Фирма {0}, доставка по тарифу {1}",
        Name, Tariff);
        return s;
    }
}
class TaxiTransCom : TransportCompany
{
    public TaxiTransCom(string name)
    : base(name)
    { }
    public override TransportService Create(string n, int c)
    {
        return new TaxiServices(Name, c);
    }
}
class ShipTransCom : TransportCompany
{
    public ShipTransCom(string name)
    : base(name)
    { }
    public override TransportService Create(string n, int t)
    {
        return new Shipping(Name, t);
    }
}

class DriverServices : TransportService
{
    public int Category { get; set; }
    public DriverServices(string name, int cat) :
    base(name)
    {
        Category = cat;
    }
    public override double CostTransportation(double distance)
    {
        return distance * Category;
    }
    public override string ToString()
    {
        string s = String.Format("Фирма {0}, поездка категории {1}",
        Name, Category);
        return s;
    }
}

class DriverTransCom : TransportCompany
{
    public DriverTransCom(string name)
    : base(name)
    { }
    public override TransportService Create(string n, int c)
    {
        return new DriverServices(Name, c);
    }
}

class Program
{
    static void Main(string[] args)
    {
        TransportCompany trCom = new TaxiTransCom("Служба такси");
        TransportService compService = trCom.Create("Такси", 1);
        double dist = 15.5;
        Console.WriteLine("Компания {0}, расстояние {1}, стоимость: {2}",
        compService.ToString(), dist, compService.CostTransportation(dist));

        TransportCompany gCom = new ShipTransCom("Служба перевозок");
        compService = gCom.Create("Грузоперевозки", 2);
        double distg = 150.5;
        Console.WriteLine("Компания {0}, расстояние {1}, стоимость: {2}",
        compService.ToString(), distg, compService.CostTransportation(distg));

        TransportCompany dCom = new DriverTransCom("Пьяный водитель");
        compService = dCom.Create("Пьяный водитель", 3);
        double distd = 30;
        Console.WriteLine("Компания {0}, расстояние {1}, стоимость: {2}",
        compService.ToString(), distd, compService.CostTransportation(distd));

    }
}
/* Фабричный метод отделяет код производства продуктов от остального кода, который 
 * эти продукты использует. Благодаря этому, код производства можно расширять, 
 * не трогая основной. Так, чтобы добавить поддержку нового продукта, вам нужно 
 * создать новый подкласс и определить в нём фабричный метод, возвращая оттуда 
 * экземпляр нового продукта.
 * 
 * Мы используем паттерн, когда заранее неизвестны типы и зависимости объектов,
 * с которыми должен работать наш код.
*/
