using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HolderComponent 
{
    public List<ItemMovableComponent> items;
    public GameObject content;
    public Vector3 direction;
    public Transform transform;
    public GameObject stopPosition;
    public bool isSocketFull;
    public float currentSpeed;
}
