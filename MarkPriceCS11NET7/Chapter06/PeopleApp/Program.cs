/*
using PacktLibrary;
 * 
 *Ejemplo de delegate
delegateName dn = new(dox);

int r = dox("yonose");
WriteLine(r);
WriteLine(dn("Yonose"));
int dox(string param)
{
    return param.Length;
}


delegate int delegateName(string param);
*/

#region EVENTOSyDELEGADOS
/*
//EJEMPLO DE UN EVENTO
Record r = new();
//suscribiendo los metodos: cuando se inicie el evento el event handler ya va saber
//cuales son los metodos que tiene que iniciar
r.eventHandler += Email;
r.eventHandler += Message;

r.Exe();


//eventos que suscriben
void Email()
{
WriteLine("Sending an E-Mail");
}

//evento que suscribe

void Message()
{
WriteLine("Sending an Message");
}

//declarando signatura del delegado
delegate void delegado();

//esta es la class que contiene el metodo que inicia el evento (exe)
class Record
{
    public event delegado eventHandler;

    public void Exe()
    {
        WriteLine("New Record created");
        if (eventHandler != null)
        {
            eventHandler();
        }
        else
        {
            WriteLine("No hay eventos que suscriben");
        }
    }
}
*/
#endregion


#region EventsEjemplo
/*
void Harry_Shout(object? sender, EventArgs r)
{
    if (sender is null) return;
    Person? p = sender as Person;
    if (p is null) return;

    WriteLine($"{p.Name} is this Angry: {p.AngerLevel}.");
}
void Harry_Shout2(object? sender, EventArgs r)
{
    if (sender is null) return;
    Person? p = sender as Person;
    if (p is null) return;

    WriteLine($"Stop it!");
}

Person Harry = new()
{
    Name = "Harry",
    DateOfBirth = DateTime.Now,
};

Harry.Shout += Harry_Shout;
Harry.Shout += Harry_Shout2;

Harry.Poke();
Harry.Poke();
Harry.Poke();
Harry.Poke();
*/

#endregion

#region INTERFACES
/*
using PacktLibrary;

namespace PeopleApp;

public partial class Program
{
    public static void Main() 
    {
        Person[] people =
        {
            new(){Name="Agustin"},
            new(){Name="Diego"},
            new(){Name="Dayana"},
            new(){Name="Carlos"},
            new(){Name=null},
            new(){Name="Liliana"},
            null,
        };

        OutputPeopleNames(people, "\tArray unsorted");
        Array.Sort(people);
        WriteLine();
        OutputPeopleNames(people, "\tAfter sorted");

    }
}
*/
#endregion

#region DEF_STRUCTTYPE
/*
using PacktLibrary;

DisplacementVector a= new(10,20);
DisplacementVector b= new(5,10);
DisplacementVector r = a + b;
WriteLine(a);
WriteLine(b);
WriteLine(r);
*/
#endregion

#region NULLABLE_PROPERTY


using PacktLibrary;

//int? thisCouldBeNull = null;
//WriteLine(thisCouldBeNull);
//WriteLine(thisCouldBeNull.GetValueOrDefault());

//thisCouldBeNull = 7;
//WriteLine(thisCouldBeNull);
//WriteLine(thisCouldBeNull.GetValueOrDefault());

/*
var address = new Address()
{
    Building = null,
    Street = null!,
    City = "",
    Region=""
};

WriteLine(address.Building?.Length);
//WriteLine(address.Building.Length);
WriteLine(address.Street?.Length);
*/
#endregion


#region NullCoalscingOperator
int exe()
{
    WriteLine("DoSomething");
    return 111;
}

forFunction f1 = exe;
int? number = null;
int? number2=default; //gonna be 0 by default

int result = number ?? f1();
WriteLine(result);

result = (number2 is null) ? 222 : f1();
WriteLine(result);


delegate int forFunction();

#endregion