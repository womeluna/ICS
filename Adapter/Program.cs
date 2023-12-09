interface ISensor
{
    int GetValue();
}
class AdapterSensor : ISensor
{
    Sensor sense;
    public AdapterSensor(Sensor x)
    {
        sense = x;
    }
    public int GetValue()
    {
        return (sense.GetValue() - 32) * 5 / 9;
    }
}
class Sensor : ISensor
{
    Random value;
    int res = 0;
    public Sensor()
    {
        value = new Random();
    }
    public int GetValue()
    {
        // Случайное значение от 32 (таяние льда) до 212 (кипение воды).
        if (res == 0)
        {
            res = value.Next(32, 212);
        }
        return res;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Sensor sense = new Sensor();
        Console.WriteLine("Температура датчика по шкале Фаренгейта: " + sense.GetValue());

        ISensor adapter = new AdapterSensor(sense);
        Console.WriteLine("Температура датчика по шкале Цельсия: " + adapter.GetValue());
    }
}
/* 
 * Шаблон Адаптер позволяет использовать сторонние классы, даже если их интерфейсы 
 * не соответствуют коду приложения. Также шаблон позволяет трансформировать данные
 * объекта в такой вид, чтобы он стал понятен другому объекту.
 * 
 * 
   Адаптер позволяет создать объект-прокладку, который будет превращать вызовы приложения в формат, понятный стороннему классу.
 */