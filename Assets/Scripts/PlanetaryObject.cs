
public class PlanetaryObject : IPlanetaryObject
{
    public MassClassEnum MassClass { get; }
    public double Mass { get; }
    public double Radius { get; }

    public PlanetaryObject(MassClassEnum massClass, double mass, double radius)
    {
        MassClass = massClass;
        Mass = mass;
        Radius = radius;
    }
}
