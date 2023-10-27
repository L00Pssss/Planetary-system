
public enum MassClassEnum
{
    Asteroidan,
    Mercurian,
    Subterran,
    Terran,
    Superterran,
    Neptunian,
    Jovian
}
public interface IPlanetaryObject
{
    MassClassEnum MassClass { get; }
    double Mass { get; }
    double Radius { get; }
}
