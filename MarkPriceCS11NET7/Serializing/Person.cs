
using System.Xml.Serialization;

public class Person
{
    private decimal Salary {get; set;}
    public Person(decimal initialSalary)
    {
        Salary=initialSalary;
    }

    public Person(){}

    [XmlAttribute("fname")]
    public string? FirstName {get; set;}
    [XmlAttribute("lname")]
    public string? Lastname {get; set;}
    [XmlAttribute("dateOB")]
    public DateTime DateOfBirth {get; set;}
    public HashSet<Person>? Chindren {get; set;}

    public void Print()
    {
        WriteLine(FirstName);
        WriteLine(Lastname);
        WriteLine(DateOfBirth.ToShortDateString());
        WriteLine("Children: {0}",Chindren?.Count ?? 0);
        WriteLine();
    }

    public static void PrintList(IEnumerable<Person>? list)
    {
        if(list is not null)
            foreach(var ob in list)
                ob.Print();
    }

}