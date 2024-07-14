using System;

abstract class Shape
{
    public abstract double CalculateArea();
}

class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

class Rectangle : Shape
{
    private double length;
    private double width;

    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    public override double CalculateArea()
    {
        return length * width;
    }
}

class Triangle : Shape
{
    private double baseLength;
    private double height;

    public Triangle(double baseLength, double height)
    {
        this.baseLength = baseLength;
        this.height = height;
    }

    public override double CalculateArea()
    {
        return 0.5 * baseLength * height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        CalculateShapeArea();
    }

    static void CalculateShapeArea()
    {
        char answer = 'y';
        while (answer == 'y')
        {
            Shape shape = GetShape();
            if (shape == null)
                continue;

            double area = shape.CalculateArea();
            Console.WriteLine($"The area of the {shape.GetType().Name} is {area}");

            Console.WriteLine("Do you wish to continue? (y/n)");
            answer = Convert.ToChar(Console.ReadLine().ToLower());
        }
    }

    static Shape GetShape()
    {
        Console.WriteLine("1. Circle");
        Console.WriteLine("2. Rectangle");
        Console.WriteLine("3. Triangle");
        Console.WriteLine("Enter the number of the shape:");
        int shapeType;
        if (!int.TryParse(Console.ReadLine(), out shapeType))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return null;
        }

        switch (shapeType)
        {
            case 1:
                Console.WriteLine("Enter the radius:");
                double radius;
                if (!double.TryParse(Console.ReadLine(), out radius))
                {
                    Console.WriteLine("Invalid input for radius");
                    return null;
                }
                return new Circle(radius);

            case 2:
                Console.WriteLine("Enter the length:");
                double length;
                if (!double.TryParse(Console.ReadLine(), out length))
                {
                    Console.WriteLine("Invalid input for length");
                    return null;
                }

                Console.WriteLine("Enter the width:");
                double width;
                if (!double.TryParse(Console.ReadLine(), out width))
                {
                    Console.WriteLine("Invalid input for width");
                    return null;
                }
                return new Rectangle(length, width);

            case 3:
                Console.WriteLine("Enter the base:");
                double baseLength;
                if (!double.TryParse(Console.ReadLine(), out baseLength))
                {
                    Console.WriteLine("Invalid input for base length");
                    return null;
                }

                Console.WriteLine("Enter the height:");
                double height;
                if (!double.TryParse(Console.ReadLine(), out height))
                {
                    Console.WriteLine("Invalid input for height");
                    return null;
                }
                return new Triangle(baseLength, height);

            default:
                Console.WriteLine("Invalid shape entered");
                return null;
        }
    }
}
