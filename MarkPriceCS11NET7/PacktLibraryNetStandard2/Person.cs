//using PacktLibraryNetStandard2;

namespace PacktLibraryNetStandard2;

public partial class Person
{
    public string name { get; set; } = "Default-name";
    public string homePlanet { get; set; } = "Earth";
    public string city { get; set; } = "Esmeraldas";
    public DateTime BirthDay { get; set; } = DateTime.Now;
    public sevenWonders favoriteWonder { get; set; }
    private string _favoritePrimaryColor = "Def-color";

    public List<Person> Children = new();


    public string origin
    {
        get
        {
            return (string.Format("{0} is from {1} from the planet {2}",
                name, city, homePlanet));
        }
    }

    public string greeting => $"{name}, says hello";
    public string getFavPrimaryColor => $"{name}'s favorite primary color is {_favoritePrimaryColor}";
    public int age => DateTime.Now.Year - BirthDay.Year;


    public string favoritePrimaryColor
    {
        get { return _favoritePrimaryColor;  }
        set
        {
            switch (value.ToLower())
            {
                case "blue":
                case "red":
                case "yellow":
                    _favoritePrimaryColor = value;
                    break;
                default:
                    throw new ArgumentException($"{value} is not a primary color. " +
                        "choose from. blue,yellow and red");
            }

            //this is marvelous!!
            /*_favoritePrimaryColor = value.ToLower() switch
            {
                "blue" or "red" or "yellow" => value,
                _ => throw new ArgumentException($"{value} is not a primary color. " +
                                        "choose from. blue,yellow and red"),
            };*/
        }

    }


}

