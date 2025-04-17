namespace PacktLibrary;

public struct DisplacementVector
{
    public int x { get; set; }
    public int y {get; set;}

    public DisplacementVector(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static DisplacementVector operator +(DisplacementVector a, DisplacementVector b)
    {
        return new (a.x + b.x, a.y + b.y);
    }

    public override string ToString()
    {
        return $"X: {x} Y: {y}";
    }

}
