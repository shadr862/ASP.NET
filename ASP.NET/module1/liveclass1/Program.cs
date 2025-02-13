Console.WriteLine("Hello, World!");

int count = 0;
count = 1;

string name1 = "1";
string name2 = "1";

int count1 = Convert.ToInt32(name1 + name2);
Console.WriteLine(count1.ToString());

count = Convert.ToInt32(name1) + Convert.ToInt32(name2);
Console.WriteLine(count.ToString());

/*
string i = "";
Console.WriteLine(Convert.ToInt32());
there is no ascii value of blank space and it will give error
*/

string msg = "";

try
{
    int j = Convert.ToInt16("");
}
catch (Exception ex)
{
    msg = ex.Message;
}

Console.WriteLine(msg);

DateTime dateTime = DateTime.Now;
Console.WriteLine(dateTime);
Console.WriteLine(dateTime.ToString("dd/mm/yyyy"));
Console.WriteLine(dateTime.ToString("dd/mm/yyyy HH:mm"));
Console.WriteLine(dateTime.ToString("dd/mm/yyyy HH:mm tt"));

//https://www.c-sharpcorner.com/blogs/date-and-time-format-in-c-sharp-programming1

string FromScreenDate = "02/01/2025";
DateTime dateTime1 = Convert.ToDateTime(FromScreenDate);// only can identify this formate mm/dd/yyy
Console.WriteLine(dateTime1.ToString("dddd, dd MMMM yyyy"));


Console.WriteLine("------------------");


DateTime dateTime2 = DateTime.ParseExact(FromScreenDate, "dd/mm/yyyy", null);
Console.WriteLine(dateTime2.ToString("dddd, dd MMMM yyyy"));


