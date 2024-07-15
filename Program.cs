using System;

// Abstract base class representing a shape
abstract class Shape
{
    // Abstract method to calculate the area of the shape
    public abstract double CalculateArea();
}

// Derived class representing a circle
class Circle : Shape
{
    private double radius;

    // Constructor to initialize the radius of the circle
    public Circle(double radius)
    {
        this.radius = radius;
    }

    // Override method to calculate the area of the circle
    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }
}

// Derived class representing a rectangle
class Rectangle : Shape
{
    private double length;
    private double width;

    // Constructor to initialize the length and width of the rectangle
    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    // Override method to calculate the area of the rectangle
    public override double CalculateArea()
    {
        return length * width;
    }
}

// Derived class representing a triangle
class Triangle : Shape
{
    private double baseLength;
    private double height;

    // Constructor to initialize the base length and height of the triangle
    public Triangle(double baseLength, double height)
    {
        this.baseLength = baseLength;
        this.height = height;
    }

    // Override method to calculate the area of the triangle
    public override double CalculateArea()
    {
        return 0.5 * baseLength * height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Start the process to calculate the area of shapes
        CalculateShapeArea();
    }

    // Method to interactively calculate the area of various shapes
    static void CalculateShapeArea()
    {
        char answer = 'y';
        while (answer == 'y')
        {
            // Get the shape from user input
            Shape shape = GetShape();
            if (shape == null)
                continue;

            // Calculate and display the area of the shape
            double area = shape.CalculateArea();
            Console.WriteLine($"The area of the {shape.GetType().Name} is {area}");

            // Ask the user if they want to continue
            Console.WriteLine("Do you wish to continue? (y/n)");
            answer = Convert.ToChar(Console.ReadLine().ToLower());
        }
    }

    // Method to get the shape details from user input
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
                // Get the radius for the circle from user input
                Console.WriteLine("Enter the radius:");
                double radius;
                if (!double.TryParse(Console.ReadLine(), out radius))
                {
                    Console.WriteLine("Invalid input for radius");
                    return null;
                }
                return new Circle(radius);

            case 2:
                // Get the length and width for the rectangle from user input
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
                // Get the base length and height for the triangle from user input
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
                // Handle invalid shape type input
                Console.WriteLine("Invalid shape entered");
                return null;
        }
    }
}
