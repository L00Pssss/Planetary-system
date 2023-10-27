using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class SimulationManager : MonoBehaviour
{
    [SerializeField] private PlanetarySystemFactory planetarySystemFactory;
    private IPlanetarySystem planetarySystem;
    private IEnumerable<IPlanetaryObject> planetaryObjects;

    [SerializeField] private GameObject celestialPrefab;
    [SerializeField] private CelestialPositions celestialPositions;
    
    
    [SerializeField] private double TotalMass = 1;
    
    private void InitializeSimulation()
    {
        planetarySystem = planetarySystemFactory.Create(TotalMass);

        planetaryObjects = planetarySystem.PlanetaryObjects;
        
        foreach (IPlanetaryObject planet in planetaryObjects)
        {
            MassClassEnum massClass = planet.MassClass;
            double mass = planet.Mass;
            double radius = planet.Radius;


            Debug.Log("Planet: MassClass = " + massClass + ", Mass = " + mass + ", Radius = " + radius);
        }
    }
    private void Awake()
    {
        InitializeSimulation();
        SpawnCelestials();
    }


    private void SpawnCelestials()
    {
        int objectCount = celestialPositions.Position.Count;

        for (int i = 0; i < objectCount; i++)
        {
            IPlanetaryObject planetaryObject = 
                planetaryObjects.ElementAt(i); // Предполагается, что planetaryObjects - это IEnumerable
            
            GameObject newObject = Instantiate(celestialPrefab, celestialPositions.Position[i].transform.position,
                Quaternion.identity);

            newObject.GetComponent<Renderer>().material = planetaryObject.Material;
            
            
            newObject.GetComponent<Rigidbody>().mass = (float)planetaryObject.Mass;

            // Устанавливаем масштаб новому объекту
            newObject.transform.localScale = new Vector3((float)planetaryObject.Radius, (float)planetaryObject.Radius,
                (float)planetaryObject.Radius);
        }
    }
    
    private void FixedUpdate()
    {
        planetarySystem.Update(Time.fixedDeltaTime);
    }
}
