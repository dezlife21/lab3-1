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

    public Parent(double pole1, double pole2)
    {
        Pole1 = pole1;
        Pole2 = pole2;
    }

    public void Print()
    {
        Console.WriteLine($"Ширина тканини: {Pole1} м, норма витрату: {Pole2} м");
    }

    public virtual double Metod()
    {
        return (2 - Pole1) * Pole2;
    }
}

class Child1 : Parent
{
    private int Pole3;

    public Child1(double pole1, double pole2, int pole3) : base(pole1, pole2)
    {
        Pole3 = pole3;
    }

    public void Print()
    {
        base.Print();
        Console.WriteLine($"Размер: {Pole3}");
    }

    public override double Metod()
    {
        return base.Metod() + ((Pole3 / 6.5 + 0.5) / 10);
    }
}

class Child2 : Parent
{
    private int Pole4;

    public Child2(double pole1, double pole2, int pole4) : base(pole1, pole2)
    {
        Pole4 = pole4;
    }

    public void Print()
    {
        base.Print();
        Console.WriteLine($"Рост: {Pole4}");
    }

    public override double Metod()
    {
        return base.Metod() + ((2 * Pole4 + 0.3) / 8);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введiть ширину тканини (м):");
        double width = double.Parse(Console.ReadLine());

        Console.WriteLine("Введiть норму витрати тканини (м/одиниця продукцiї):");
        double rate = double.Parse(Console.ReadLine());

        Console.WriteLine("Введiть розмiр пальто (наприклад, 44, 46, 48, 50 ...):");
        int size = int.Parse(Console.ReadLine());

        Console.WriteLine("Введiть рiст (наприклад, 1, 2, 3, 4):");
        int height = int.Parse(Console.ReadLine());

        Parent parentObj = new Parent(width, rate);
        Child1 child1Obj = new Child1(width, rate, size);
        Child2 child2Obj = new Child2(width, rate, height);

        parentObj.Print();
        Console.WriteLine($"Витрата тканини: {parentObj.Metod()} м\n");
        child1Obj.Print();
        Console.WriteLine($"Витрата тканини: {child1Obj.Metod()} м\n");
        child2Obj.Print();
        Console.WriteLine($"Витрата тканини: {child2Obj.Metod()} м");
    }
}