abstract class Command
{
    protected ArithmeticUnit unit;
    protected double operand;
    public abstract void Execute();
    public abstract void UnExecute();
}
class ArithmeticUnit
{
    public double Register { get; private set; }
    public void Run(char operationCode, double operand)
    {
        switch (operationCode)
        {
            case '+':
                Register += operand;
                break;
            case '-':
                Register -= operand;
                break;
            case '*':
                Register *= operand;
                break;
            case '/':
                Register /= operand;
                break;
        }
    }
}
class ControlUnit
{
    private List<Command> commands = new List<Command>();
    private int current = 0;
    public void StoreCommand(Command command)
    {
        commands.Add(command);
    }
    public void ExecuteCommand()
    {
        commands[current].Execute();
        current++;
    }
    public void Undo()
    {
        commands[current - 1].UnExecute();
    }
    public void Undo(int x)
    {
        for (int i = 0; i < x; i++)
        {
            commands[current - 1].UnExecute();
        }
    }
    public void Redo()
    {
        commands[current - 1].Execute();
    }
    public void Redo(int x)
    {
        for (int i = 0; i < x; i++)
        {
            commands[current - 1].Execute();
        }
    }
}
class Add : Command
{
    public Add(ArithmeticUnit unit, double operand)
    {
        this.unit = unit;
        this.operand = operand;
    }
    public override void Execute()
    {
        unit.Run('+', operand);
    }
    public override void UnExecute()
    {
        unit.Run('-', operand);
    }
}
class Sub : Command
{
    public Sub(ArithmeticUnit unit, double operand)
    {
        this.unit = unit;
        this.operand = operand;
    }
    public override void Execute()
    {
        unit.Run('-', operand);
    }
    public override void UnExecute()
    {
        unit.Run('+', operand);
    }
}
class Mul : Command
{
    public Mul(ArithmeticUnit unit, double operand)
    {
        this.unit = unit;
        this.operand = operand;
    }
    public override void Execute()
    {
        unit.Run('*', operand);
    }
    public override void UnExecute()
    {
        unit.Run('/', operand);
    }
}
class Div : Command
{
    public Div(ArithmeticUnit unit, double operand)
    {
        this.unit = unit;
        this.operand = operand;
    }
    public override void Execute()
    {
        unit.Run('/', operand);
    }
    public override void UnExecute()
    {
        unit.Run('*', operand);
    }
}
class Calculator
{
    ArithmeticUnit arithmeticUnit;
    ControlUnit controlUnit;
    public Calculator()
    {
        arithmeticUnit = new ArithmeticUnit();
        controlUnit = new ControlUnit();
    }
    private double Run(Command command)
    {
        controlUnit.StoreCommand(command);
        controlUnit.ExecuteCommand();
        return arithmeticUnit.Register;
    }
    public double Undo()
    {
        controlUnit.Undo();
        return arithmeticUnit.Register;
    }
    public double Redo()
    {
        controlUnit.Redo();
        return arithmeticUnit.Register;
    }
    public double Undo(int x)
    {
        controlUnit.Undo(x);
        return arithmeticUnit.Register;
    }
    public double Redo(int x)
    {
        controlUnit.Redo(x);
        return arithmeticUnit.Register;
    }
    public double Add(double operand)
    {
        return Run(new Add(arithmeticUnit, operand));
    }
    public double Sub(double operand)
    {
        return Run(new Sub(arithmeticUnit, operand));
    }
    public double Mul(double operand)
    {
        return Run(new Mul(arithmeticUnit, operand));
    }
    public double Div(double operand)
    {
        return Run(new Div(arithmeticUnit, operand));
    }
}

class Program
{
    static void Main(string[] args)
    {
        var calculator = new Calculator();
        double result = 0;
        result = calculator.Add(5);
        Console.WriteLine(result);
        result = calculator.Add(4);
        Console.WriteLine(result);
        result = calculator.Add(3);
        Console.WriteLine(result);
        result = calculator.Redo(3);
        Console.WriteLine(result);
        result = calculator.Undo(2);
        Console.WriteLine(result);

    }
}

/*
Команда превращает операции в объекты. А объекты можно передавать, хранить и взаимозаменять внутри других объектов.
Как и любые другие объекты, команды можно сериализовать, то есть превратить в строку, чтобы потом сохранить в файл
или базу данных. Затем в любой удобный момент её можно достать обратно, снова превратить в объект команды и выполнить.
Таким же образом команды можно передавать по сети, логировать или выполнять на удалённом сервере.
 */