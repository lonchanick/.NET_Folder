namespace PacktLibraryNetStandard2;

public class Passenger
{
    public string? Name { get; set; }
}

public class BuisinessClassPassenger : Passenger
{
    public override string ToString()
    {
        return $"Buisiness Class Passenger {Name}";
    }
}

public class FirstClassPassenger : Passenger
{
    public int AirMiles { get; set; }
    public override string ToString()
    {
        return $"First Class Passenger with {AirMiles:N0} miles, {Name} ";
    }
}

public class CoachClassPassenger : Passenger
{
    public double CarryOnKG { get; set; }
    public override string ToString()
    {
        return $"CoachClassPassenger with {CarryOnKG}KG on carry on, {Name} ";
    }
}
