class point { }
class line { }
abstract class Route
{
    public point Start { get; set; }
    public point End { get; set; }
    public line result;
    public Route (point A, point B) 
    {
        Start = A;
        End = B;    
    }
    public void TemplateMethod()
    {
        InitializeRoute(Start, End);
        BuildingRoute();
        PrintRoute(result);
    }
    private void InitializeRoute (point A, point B)
    {
        Start = A;
        End = B;
    }
    private void PrintRoute (line result)
    {
        Console.WriteLine("Построенный маршрут: ");
        Console.WriteLine(result);
    }
    public abstract void BuildingRoute();
}
 


class RoadRoute : Route
{
    public RoadRoute(point A, point B): base(A, B) { }
    public override void BuildingRoute()
    { 

    }
}
class PublicTransportRoute : Route
{
    public PublicTransportRoute(point A, point B) : base(A, B) { }
    public override void BuildingRoute()
    {

    }
}
class WalkingRoute : Route
{
    public WalkingRoute(point A, point B) : base(A, B) { }
    public override void BuildingRoute()
    {

    }
}
class TourismRoute : Route
{
    public TourismRoute(point A, point B) : base(A, B) { }
    public override void BuildingRoute()
    {

    }
}

/* Паттерн шаблонный метод предлагает создать для похожих
 * классов общий суперкласс и оформить в нём главный алгоритм
 * в виде шагов. Отличающиеся шаги можно переопределить в подклассах.
 *  Мы используем шаблон, когда есть несколько классов, делающих одно
 *  и то же с незначительными отличиями.
 *  
 *  Паттерн Шаблонный метод отличается от паттерна Стратегия тем, что
 *  в шаблонном методе мы создаём класс, наследующий от шаблона, в котором
 *  переопределяем некоторый функционал, а в паттерне Статегия мы создаём
 *  алгоритм решения задачи, который мы подставляем в общее решение.
*/
