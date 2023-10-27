using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCollection : MonoBehaviour
{
    [SerializeField] private List<Material> material;

    public List<Material> Material => material;
}
