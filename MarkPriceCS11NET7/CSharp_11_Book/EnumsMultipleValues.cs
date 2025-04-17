namespace CSharp_11_Book;

[Flags]
enum Days:Byte
{
    Monday = 0B_0000_0001,
    Tusday = 0B_0000_0010,
    Wednesday = 0B_0000_0100,
    Thursday = 0B_0000_1000,
    Friday = 0B_0001_0000,
    Saturday = 0B_0010_0000,
    Sunday = 0B_0100_0000
}

public class EnumsMultipleValues
{
    public static void exe()
    {
        Days homeWorkDays = Days.Monday | Days.Thursday;

        WriteLine(homeWorkDays);

        if ((homeWorkDays & Days.Monday) != 0)
            WriteLine("Today {0}, you work from home",Days.Monday);
        else
            WriteLine("You gotta go to the office");

    }
}
