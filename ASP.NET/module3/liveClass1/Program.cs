// See https://aka.ms/new-console-template for more information
using liveClass1;
//Encapsolution
/*
Console.WriteLine("Enter Your name:");
string name = Console.ReadLine();
Console.WriteLine("Enter Your age:");
int Age = Convert.ToInt16(Console.ReadLine());
Console.WriteLine("Enter Your Degree Name:");
string DegName = Console.ReadLine();

Human Obj = new Human(name,Age,DegName);
Console.WriteLine(Obj.BioData());


Animal objAnimal = new Animal();
Console.WriteLine(objAnimal.GetSound("cat"));
Console.WriteLine(objAnimal.GetSound("dog"));
Console.WriteLine(objAnimal.GetSound("false"));
*/

//polymorphism
/*
Human objhuman = new Human();
Console.WriteLine("with No Argument: " + objhuman.BioData());
Console.WriteLine("with Argument: " + objhuman.BioData("Riaz",27,"BSC"));
*/
//Inheretance
Human objhuman = new Human();
Console.WriteLine(objhuman.BioData("Riaz", 27, "BSC","Islam"));
//interface
Console.WriteLine(objhuman.GetHobby("Coding"));

