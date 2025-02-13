// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        for (int j = 0; j < 6; j++)
        {
            j++;
            Console.WriteLine(j);
            j = 6;
        }

        int i = 1;
        while (i > 0)
        {
            i++;
            Console.WriteLine(i);
            if (i == 10)
                i = 0;
        }

        string[] strArray = { "abc", "xyz", "pqr" };
        int[] sArray = { 1, 2, 3 };
        foreach (string item in strArray)
        {
            Console.WriteLine(item);
        }

        List<Human> strings = new List<Human>();
        Human human = new Human();
        human.name = "Rahim";
        strings.Add(human);

        human = new Human();
        human.name = "Karim";
        strings.Add(human);


        foreach (Human item in strings)
        {
            Console.WriteLine("Person name is:" + item.name);
            Console.WriteLine("-----------------------");
        }

        //  *
        // ***
        //*****



        Console.ReadLine();
    }
}