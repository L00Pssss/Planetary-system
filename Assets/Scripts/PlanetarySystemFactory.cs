using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

[Serializable]
public class PlanetarySystemFactory : IPlanetarySystemFactory
{
    
    [Serializable]
    private class MassClassParameters
    {
        public MassClassEnum massClassEnum;
        public float maxMass;
        public float minMass;
        public float maxRadius;
        public float minRadius;
    }

    [SerializeField] private MassClassParameters[] massClassParameters;
    public IPlanetarySystem Create(double mass)
    {
        List<IPlanetaryObject> planets = new List<IPlanetaryObject>();
        for (int i = 0; i < massClassParameters.Length; i++)
        {
            planets.Add(new PlanetaryObject(massClassParameters[i].massClassEnum,
                Random.Range(massClassParameters[i].minMass,massClassParameters[i].maxMass),
                mass * Random.Range(massClassParameters[i].minRadius,massClassParameters[i].maxRadius)));
        }
        
        IPlanetarySystem system = new PlanetarySystem(planets);
        

        return system;
    }
    
    
    
}