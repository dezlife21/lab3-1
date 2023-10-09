using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System;
class Parent
{
    protected double Pole1;
    protected double Pole2;
    protected double Pole3;
    protected double Pole4;

    public Parent()
    {
        Pole1 = 0;
        Pole2 = 0;
        Pole3 = 0;
        Pole4 = 0;
    }

    public Parent(double side1, double side2, double angleDegrees)
    {
        Pole1 = side1;
        Pole2 = side2;
        Pole3 = angleDegrees;
        Pole4 = (angleDegrees * Math.PI) / 180;
    }

    public void Print()
    {
        Console.WriteLine($"Сторона (1) = {Pole1}, Сторона (2) = {Pole2}, Кут (градуси) = {Pole3}, Кут (радiани) = {Pole4:F2}");
    }

    public double Metod1()
    {
        return Pole1 * Pole2 * Math.Sin(Pole4);
    }

    public Tuple<double, double> Metod2()
    {
        double diagonal2 = Math.Sqrt(Math.Pow(Pole1, 2) + Math.Pow(Pole2, 2) - 2 * Pole1 * Pole2 * Math.Cos(Pole4));
        double diagonal1 = Math.Sqrt(Math.Pow(Pole1, 2) + Math.Pow(Pole2, 2) + 2 * Pole1 * Pole2 * Math.Cos(Pole4));

        return Tuple.Create(diagonal1, diagonal2);
    }
}

class Child : Parent
{
    public Child(double side, double acuteAngle) : base(side, side, acuteAngle)
    {

    }

    public double Metod3()
    {
        return (Math.Pow(Pole1, 2) * Math.Sin(Pole4)) / 2;
    }

    public double Metod4()
    {
        return 4 * Pole1;
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Введiть сторону 1:");
            double side1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введiть сторону 2:");
            double side2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Введiть кут (градуси):");
            double angle = double.Parse(Console.ReadLine());

            if (side1 != side2)
            {
                Parent parentObj = new Parent(side1, side2, angle);
                Console.WriteLine("Паралелограм:");
                parentObj.Print();
                Console.WriteLine($"Площа: {parentObj.Metod1():F2}");
                Tuple<double, double> diagonals = parentObj.Metod2();
                Console.WriteLine($"Дiагональ 1: {diagonals.Item1:F2}  Дiагональ 2: {diagonals.Item2:F2}");
            }
            else
            {
                Child childObj = new Child(side1, angle);
                Console.WriteLine("Ромб:");
                childObj.Print();
                Console.WriteLine($"Площа вписаного кола: {childObj.Metod3():F2}");
                Console.WriteLine($"Довжина вписаного кола: {childObj.Metod4():F2}");
            }

            Console.WriteLine("Бажаєте продовжити (так/нi)?");
            string continueInput = Console.ReadLine().ToLower();
            if (continueInput != "так" && continueInput != "yes")
                break;
        }
    }
}