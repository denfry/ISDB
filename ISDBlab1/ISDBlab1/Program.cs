using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите длину массива:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите элементы массива, разделенные пробелами:");
        string[] parts = Console.ReadLine().Split();
        double[] array = new double[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = double.Parse(parts[i]);
        }

        Console.WriteLine("Введите значение A:");
        double A = double.Parse(Console.ReadLine());
        int count = 0;
        foreach (double x in array)
        {
            if (x > A) count++;
        }
        Console.WriteLine("Количество элементов, больших A: " + count);

        Console.WriteLine("Введите значение B:");
        double B = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите значение C:");
        double C = double.Parse(Console.ReadLine());

        int newCount = 0;
        foreach (double x in array)
        {
            if (x > B && x < C) newCount++;
        }

        double[] newArray = new double[newCount];
        int index = 0;
        foreach (double x in array)
        {
            if (x > B && x < C)
            {
                newArray[index] = x;
                index++;
            }
        }

        Console.WriteLine("Новый массив:");
        Console.WriteLine(string.Join(" ", newArray));
    }
}