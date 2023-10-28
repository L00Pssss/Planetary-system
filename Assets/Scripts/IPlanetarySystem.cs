using System.Collections.Generic;
using UnityEngine;

public interface IPlanetarySystem 
{
    IEnumerable<IPlanetaryObject> PlanetaryObjects { get;}

    void SetPlanetSpawnObjects(List<GameObject> planetSpawnObjects); // Добавляем метод для установки объектов

    void Update(float deltaTime);

}
