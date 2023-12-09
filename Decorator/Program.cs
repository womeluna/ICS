public abstract class AutoBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double CostBase { get; set; }
    public abstract double GetCost();
    public override string ToString()
    {
        string s = String.Format("Ваш автомобиль: \n{0} \nОписание: {1} \nСтоимость {2}\n",
        Name, Description, GetCost());
        return s;
    }
}
class Renault : AutoBase
{
    public Renault(string name, string info, double costbase)
    {
        Name = name;
        Description = info;
        CostBase = costbase;
    }
    public override double GetCost()
    {
        return CostBase * 1.18;
    }
}
class DecoratorOptions : AutoBase
{
    public AutoBase AutoProperty { protected get; set; }
    public string Title { get; set; }
    public DecoratorOptions(AutoBase au, string tit)
    {
        AutoProperty = au;
        Title = tit;
    }
    public override double GetCost()
    {
        return AutoProperty.GetCost();
    }
}
class MediaNAV : DecoratorOptions
{
    public MediaNAV(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Современный";
        Description = p.Description + ". " + this.Title + ". Обновленная мультимедийная навигационная система";
   

 }
    public override double GetCost()
    {
        return AutoProperty.GetCost() + 15.99;
    }
}
class SystemSecurity : DecoratorOptions
{
    public SystemSecurity(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Повышенной безопасности";
        Description = p.Description + ". " + this.Title + ". Передние боковые подушки безопасности, ESP -система динамической стабилизации автомобиля";
    }
    public override double GetCost()
    {
        return AutoProperty.GetCost() + 20.99;
    }
}
class Audi : AutoBase
{
    public Audi(string name, string info, double costbase)
    {
        Name = name;
        Description = info;
        CostBase = costbase;
    }
    public override double GetCost()
    {
        return CostBase * 1.25;
    }
}
class ClimateControl : DecoratorOptions
{
    public ClimateControl(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Тёплый";
        Description = p.Description + ". " + this.Title + ". Система климат-контроля";


    }
    public override double GetCost()
    {
        return AutoProperty.GetCost() + 25;
    }
}
class HeatedSeats: DecoratorOptions
{
    public HeatedSeats(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". С подогревом";
        Description = p.Description + ". " + this.Title + ". Подогрев сидений";
    }
    public override double GetCost()
    {
        return AutoProperty.GetCost() + 15;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Renault reno = new Renault("Рено", "Renault LOGAN Active", 499.0);
        Print(reno);
        AutoBase myreno = new MediaNAV(reno, "Навигация");
        Print(myreno);
        AutoBase newmyReno = new SystemSecurity(new MediaNAV(reno, "Навигация"),"Безопасность");
        Print(newmyReno);

    }
    private static void Print(AutoBase av)
    {
        Console.WriteLine(av.ToString());
    }
}
/*
    Используем паттерн, когда нельзя расширить обязанности объекта с помощью наследования.

    Декоратор, в отличие от наследования, позволяет не создавать все возможные комбинации
    функций объекта, а комбинировать их, создав для каждого функционала отдельный класс.

 */
