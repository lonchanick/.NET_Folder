namespace PacktLibraryNetStandard2;

public partial class Person
{
    private bool married = false;
    public bool Married => married;

    private Person? spouse = null;
    public Person? Spouse => spouse;

    public static void Marry(Person p1, Person p2)
    {
        p1.Marry(p2);
    }

    public void Marry(Person partner)
    {
        if (Married) return;
            //throw new Exception($"{this.name} is already married");
        spouse = partner; 
        married = true;
        partner.Marry(this);

    }

    public static Person Procreate(Person p1, Person p2)
    {
        if (p1.spouse!=p2)
        {
            throw new ArgumentException("You must be married");
        }

        Person child = new()
        {
            name = string.Format("child of {0} and {1}", p1.name, p2.name),
            BirthDay = DateTime.Now
        };

        p1.Children.Add(child);
        p2.Children.Add(child);

        return child;
    }

    public Person ProcreateWith(Person p1)
    {
        return Procreate(p1, this);
    }
    
    
    public override string ToString()
    {
        string b = $"{name} is married to {spouse.name} and have {this.Children.Count()} children";
        return b;
    }


    //implementing functionalities using operators

    public static bool operator + (Person p1, Person p2)
    {
        Person.Marry(p1, p2);
        return p1.married && p2.married;
    }

    //go forth and multiply
    public static Person operator * (Person p1, Person p2)
    {
        return Procreate(p1,p2);
    }


}
