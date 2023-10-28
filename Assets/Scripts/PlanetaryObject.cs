using UnityEngine;

public class PlanetaryObject : IPlanetaryObject
{
    public MassClassEnum MassClass { get; }
    public double Mass { get; }
    public double Radius { get; }

    public Material Material { get; }

    public Transform PositionPointStart { get; }

    public PlanetaryObject(MassClassEnum massClass, double mass, double radius, Material material, Transform positionPointStart)
    {
        MassClass = massClass;
        Mass = mass;
        Radius = radius;
        Material = material;
        PositionPointStart = positionPointStart;
    }
}
