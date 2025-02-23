// See https://aka.ms/new-console-template for more information
using livetest;

Console.WriteLine("Hello, World!");
// Value Type (int)

int a = 10;
int b = a; // Copy of 'a'
b = 20;
Console.WriteLine(a); // Output: 10

// Reference Type (class)


Person p1 = new Person();
p1.Name = "John";
Person p2 = p1; // Reference to 'p1'
p2.Name = "Doe";
Console.WriteLine(p1.Name); // Output: Doe