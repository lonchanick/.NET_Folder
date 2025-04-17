using System.Security.AccessControl;

namespace CSharp_11_Book;

class Animal
{
    public string Name { get; set; }
    public string Breed { get; set; }

}
class Dog : Animal
{
    public bool Strong { get; set; } 
}

class Cat : Animal
{
    public bool Wild { get; set; }
}

public class SwitchAndClasses
{
    /// <summary>
    /// esto define varios tipos de animales para luego usar
    /// switch expressions para determinar sus propiedades
    /// dependiendo del caso :0 (xml comments!)
    /// </summary>
    public static void exe()
    {
        Animal?[] animals = new Animal[]
        {
            new Cat {Name = "CatDog", Breed ="Michifú", Wild = true},
            new Cat {Name = "Garfield", Breed ="Michifá", Wild = false},
            new Dog { Name = "Chiquiño", Breed ="Pitbull", Strong = true},
            new Dog { Name = "Choky", Breed ="Not even god Knows", Strong = false},
            null
        };

        foreach(var a in animals)
        {
            string Message=String.Empty;
            Message = a switch
            {
                Cat wildCat when wildCat.Wild == true
                    => Message = $"{wildCat.Name.ToUpper()}, is a wild cat!!",
                
                Cat normalCat when normalCat.Wild == false
                    => Message = $"{normalCat.Name.ToUpper()} is not a wild cat, you can pet the cat",

                Dog isStrong when isStrong.Strong == true
                    => Message = $"{isStrong.Name.ToUpper()} is a {isStrong.Breed.ToUpper()} breed! hold on firm the leash!",
                
                Dog isNotStrong when isNotStrong.Strong == false
                    =>Message = $"{isNotStrong.Name.ToUpper()} is just a \"{isNotStrong.Breed.ToUpper()}\" breed dont worry!",
                
                null
                    => ("This is a null reference, there is no values here"),
                
                _ //representa cualquier cosa
                    =>("In this example this option will never be used")
            };
            WriteLine(Message);
        }

    }
}
