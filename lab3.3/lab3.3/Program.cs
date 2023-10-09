using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
class Parent
{
    protected int Pole1;
    protected int Pole2;
    protected int Pole3;

    public Parent(int totalPlaces)
    {
        Pole1 = totalPlaces;
        Pole2 = 0;
        Pole3 = totalPlaces;
    }

    public void Print()
    {
        Console.WriteLine($"Всього мiсць: {Pole1}, Зайнято: {Pole2}, Вiльно: {Pole3}");
    }

    public bool Metod1()
    {
        if (Pole3 > 0)
        {
            Pole2++;
            Pole3--;
            return true;
        }
        return false;
    }

    public bool Metod2()
    {
        if (Pole2 > 0)
        {
            Pole2--;
            Pole3++;
            return true;
        }
        return false;
    }
}

class Child : Parent
{
    private int Pole4;

    public Child(int totalPlaces) : base(totalPlaces)
    {
        Pole4 = 0;
    }

    public void Print()
    {
        base.Print();
        Console.WriteLine($"Кiлькiсть лiкарiв: {Pole4}");
    }

    public void Metod3()
    {
        Pole4 = Pole2 / 3 + 1; // Розрахунок кількості лікарів
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Створення готелю на 5 мiсць:");
        Parent hotel = new Parent(5);
        hotel.Print();

        int guestsInHotel = new Random().Next(1, 6); // Випадкова кількість гостей
        Console.WriteLine($"Гостей, якi приїхали в готель: {guestsInHotel}");

        for (int i = 0; i < guestsInHotel; i++)
        {
            if (hotel.Metod1())
            {
                Console.WriteLine($"Гiсть {i + 1} поселився.");
            }
            else
            {
                Console.WriteLine($"Мiсця закiнчились, гiсть {i + 1} не змiг поселитися.");
            }
        }

        int guestsLeavingHotel = new Random().Next(1, guestsInHotel + 1); // Випадкова кількість гостей, які виїжджають
        Console.WriteLine($"Гостей, якi виїжджають з готелю: {guestsLeavingHotel}");

        for (int i = 0; i < guestsLeavingHotel; i++)
        {
            if (hotel.Metod2())
            {
                Console.WriteLine($"Гiсть {i + 1} виселився.");
            }
            else
            {
                Console.WriteLine($"Готель порожнiй, гiсть {i + 1} не може виселитися.");
            }
        }

        hotel.Print();

        Console.WriteLine("\nСтворення санаторiю на 5 мiсць:");
        Child sanatorium = new Child(5);
        sanatorium.Print();

        int patientsInSanatorium = new Random().Next(1, 6); // Випадкова кількість пацієнтів
        Console.WriteLine($"Пацiєнтiв, якi приїхали в санаторiй: {patientsInSanatorium}");

        for (int i = 0; i < patientsInSanatorium; i++)
        {
            if (sanatorium.Metod1())
            {
                Console.WriteLine($"Пацiєнт {i + 1} прийшов.");
            }
            else
            {
                Console.WriteLine($"Мiсця закiнчились, пацiєнт {i + 1} не змiг прийти.");
            }
        }

        sanatorium.Metod3();
        sanatorium.Print();

        int patientsLeavingSanatorium = new Random().Next(1, patientsInSanatorium + 1); // Випадкова кількість пацієнтів, які виїжджають
        Console.WriteLine($"Пацiєнтiв, якi виїжджають з санаторiю: {patientsLeavingSanatorium}");

        for (int i = 0; i < patientsLeavingSanatorium; i++)
        {
            if (sanatorium.Metod2())
            {
                Console.WriteLine($"Пацiєнт {i + 1} виписався.");
            }
            else
            {
                Console.WriteLine($"Санаторiй порожнiй, пацiєнт {i + 1} не може виписатися.");
            }
        }

        sanatorium.Metod3();
        sanatorium.Print();
    }
}