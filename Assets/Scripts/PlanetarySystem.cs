using System.Collections.Generic;

public class PlanetarySystem : IPlanetarySystem
{
    private List<IPlanetaryObject> planetaryObjects;
    
    public PlanetarySystem(List<IPlanetaryObject> initialPlanetaryObjects)
    {
        planetaryObjects = initialPlanetaryObjects;
    }

    public IEnumerable<IPlanetaryObject> PlanetaryObjects => planetaryObjects;


    public void Update(float deltaTime)
    {
        foreach (var a in planetaryObjects)
        {
         //   a.postion = 
        }
    }
}