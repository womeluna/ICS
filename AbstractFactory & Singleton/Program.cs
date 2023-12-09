abstract class CarFactory
{
    public abstract AbstractCar CreateCar();
    public abstract AbstractEngine CreateEngine();
}
abstract class AbstractCar
{
    public string Name { get; set; }
    public abstract int MaxSpeed(AbstractEngine engine);
    public string Auto_Body { get; set; }
}
abstract class AbstractEngine
{
    public int max_speed { get; set; }
}
class FordFactory : CarFactory
{
    FordFactory() {}
    static FordFactory myFactory = null;
    public static FordFactory MyFactory
    {
        get
        {
            if (myFactory == null)
            {
                myFactory = new FordFactory();
            }  
            return myFactory;
        }
    }
    public override AbstractCar CreateCar()
    {
        return new FordCar("Форд","хэчбэк");
    }
    public override AbstractEngine CreateEngine()
    {
        return new FordEngine();
    }
}
class FordCar : AbstractCar
{
    public FordCar(string name, string auto_body)
    {
        Name = name;
        Auto_Body = auto_body;
    }
    public override int MaxSpeed(AbstractEngine engine)
    {
        int ms = engine.max_speed;
        return ms;
    }
    public override string ToString()
    {
        return "Автомобиль " + Name + " с типом кузова " + Auto_Body;
    }
}
class FordEngine : AbstractEngine
{
    public FordEngine()
    {
        max_speed = 220;
    }
}
class AudiFactory : CarFactory
{
    public override AbstractCar CreateCar()
    {
        return new AudiCar("Ауди", "cедан");
    }
    public override AbstractEngine CreateEngine()
    {
        return new AudiEngine();
    }
}
class AudiCar : AbstractCar
{
    public AudiCar(string name, string auto_body)
    {
        Name = name;
        Auto_Body=auto_body;
    }
    public override int MaxSpeed(AbstractEngine engine)
    {
        int ms = engine.max_speed;
        return ms;
    }
    public override string ToString()
    {
        return "Автомобиль " + Name + " с типом кузова " + Auto_Body;
    }
}
class AudiEngine : AbstractEngine
{
    public AudiEngine()
    {
        max_speed = 300;
    }
}
class Client
{
    private AbstractCar abstractCar;
    private AbstractEngine abstractEngine;
    public Client(CarFactory car_factory)
    {
        abstractCar = car_factory.CreateCar();
        abstractEngine = car_factory.CreateEngine();
    }
    public int RunMaxSpeed()
    {
        return abstractCar.MaxSpeed(abstractEngine);
    }
    public override string ToString()
    {
        return abstractCar.ToString();
    }
}
class Program
{
    static void Main(string[] args)
    {
        CarFactory ford_car = FordFactory.MyFactory;
        Client c1 = new Client(ford_car);
        Console.WriteLine("Максимальная скорость {0} составляет {1} км/час",
        c1.ToString(), c1.RunMaxSpeed());
        CarFactory audi_car = new AudiFactory();
        Client c2 = new Client(audi_car);
        Console.WriteLine("Максимальная скорость {0} составляет {1} км/час",
        c2.ToString(), c2.RunMaxSpeed());
    }
}
/*Абстрактная фабрика скрывает от клиентского кода подробности того, как и какие
 * конкретно объекты будут созданы. Но при этом клиентский код может работать со
 * всеми типами создаваемых продуктов, поскольку их общий интерфейс был заранее определён.
   Трудоемкость изменений, внесённых по заданию, не велика, что позволяет быстро создавать
аналогичные объекты.
    
    Мы используем шаблон, когда бизнес-логика программы должна работать с разными видами
    связанных друг с другом продуктов, не завися от конкретных классов продуктов.

На примере класса фабрики Форд реализован паттерн Одиночка. Данный паттерн применяется,
когда в программе должен быть единственный экземпляр какого-то класса. Одиночка скрывает 
от клиентов все способы создания нового объекта, кроме специального метода. Этот метод
либо создаёт объект, либо отдаёт существующий объект, если он уже был создан.
 */