// See https://aka.ms/new-console-template for more information
using LiveClass2;

Console.WriteLine("Hello, World!");
//Constructor
/*
Humam objHuman = new Humam();
Console.WriteLine(objHuman.Information());
Console.WriteLine(objHuman.Information("Riaz",27));
MyTask task = new MyTask();
objHuman.ListTask.Add(task);
Console.WriteLine(objHuman.myTask.TaskName);
*/
// Static Function
/*
 we donot need create object
 because we can call it by class name
 and we cannot use this keyword as we do not hold data
 Console.WriteLine(MyTask.TaskNumber());
*/
//partial class
/*
Passport obj = new Passport();
obj.PassportName = "Riaz";
obj.PassportNo = "1234235325";
obj.PassportAddress = "98/34";

Console.WriteLine(obj.PassportName + " " + obj.PassportNo + " " + obj.PassportAddress);
*/
//Abstraction
//Abstract class can not be initiated
//derive class must be implement all abstact fuction and variable
//it can have non abstract function and variable
Humam obj = new Humam();
Console.WriteLine(obj.GetStationaryName("pen"));
Console.WriteLine(obj.GetStationaryInformation());