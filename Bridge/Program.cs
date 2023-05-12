Figure abstraction;
// Клиентский код должен работать с любой предварительно
// сконфигурированной комбинацией абстракции и реализации.
abstraction = new Figure(new RedColor());
Client.ClientCode(abstraction);

Console.WriteLine();

abstraction = new Square(new BlueColor());
Client.ClientCode(abstraction);

abstraction = new Sphere(new YellowColor());
Client.ClientCode(abstraction);


// Абстракция содержит ссылку на объект Реализации и
// делегирует ему всю настоящую работу.
class Figure
{
    protected IColor _color;

    public Figure(IColor c)
    {
        this._color = c;
    }

    public virtual string Operation()
    {
        return "Фигура " + _color.OperationImplementation();
    }
}

// Расширение Абстракции
class Square : Figure
{
    public Square(IColor color) : base(color)
    {
    }

    public override string Operation()
    {
        return "Квадрат " + base._color.OperationImplementation();
    }
}
class Sphere : Figure
{
    public Sphere(IColor color) : base(color)
    {
    }

    public override string Operation()
    {
        return "Сфера " + base._color.OperationImplementation();
    }
}

// Интерфейс реализации
public interface IColor
{
    string OperationImplementation();
}

// Конкретные Реализации
class RedColor : IColor
{
    public string OperationImplementation()
    {
        return "красного цвета\n";
    }
}
class BlueColor : IColor
{
    public string OperationImplementation()
    {
        return "синего цвета\n";
    }
}
class YellowColor : IColor
{
    public string OperationImplementation()
    {
        return "желтого цвета\n";
    }
}

class Client
{
    // клиентский код должен зависеть только от класса Абстракции
    public static void ClientCode(Figure abstraction)
    {
        Console.Write(abstraction.Operation());
    }
}
