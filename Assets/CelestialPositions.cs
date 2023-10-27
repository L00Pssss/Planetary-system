using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialPositions : MonoBehaviour
{
    [SerializeField] private List<GameObject> position;

    public List<GameObject> Position => position;
}
