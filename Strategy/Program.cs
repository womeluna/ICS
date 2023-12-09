abstract class StrategyRoute
{
 public string Title { get; set; }
public abstract void buildRoute(point a, point b);
 }

class point { }
class RoadRoute : StrategyRoute {
    public override void buildRoute(point a, point b) { }
}
class PublicTransportRoute : StrategyRoute { 
    public override void buildRoute(point a, point b) { }
}
class WalkingRoute : StrategyRoute {
    public override void buildRoute(point a, point b) { }
}
class TourismRoute : StrategyRoute {
    public override void buildRoute(point a, point b) { }
}
class Context
{
    StrategyRoute strategy;
    point a;
    point b;
    public Context(StrategyRoute strategy, point a, point b)
    {
        this.strategy = strategy;
        this.a = a;
        this.b = b;
    }
    public void buildRoute()
    {
        strategy.buildRoute(a, b);
    }
    public void showMap()
    {

    }

}
/* Паттерн Стратегия позволяет использовать разные варианты алгоритма внутри одного объекта, подставляя в него различные объекты-поведения.
 * 
*/
