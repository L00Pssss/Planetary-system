using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystem : IPlanetarySystem
{
    private List<IPlanetaryObject> planetaryObjectsProperties;
    
    public List<GameObject> planetaryObjects;


    public PlanetarySystem(List<IPlanetaryObject> initialPlanetaryObjectsProperties)
    {
        planetaryObjectsProperties = initialPlanetaryObjectsProperties;
    }
    
    public void SetPlanetSpawnObjects(List<GameObject> planetSpawnObjects)
    {
        planetaryObjects = planetSpawnObjects;
        CalculateInitialVelocity();
    }

    public IEnumerable<IPlanetaryObject> PlanetaryObjects => planetaryObjectsProperties;
    
    readonly float G = 100f;

    public void Update(float deltaTime)
    {
        foreach (var a in planetaryObjects)
        {
            foreach (var b in planetaryObjects)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                }
            }
        }
    }
    
    
    private void CalculateInitialVelocity()
    {
        // Расчет начальных скоростей
        foreach (var a in planetaryObjects)
        {
            foreach (var b in planetaryObjects)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.transform.LookAt(b.transform);
                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2) / r);
                }
            }
        }
    }
}