using Leopotam.Ecs;
using UnityEngine;

public struct ItemMovableComponent 
{
    public Transform transform;
    public Vector3 direction;
    public HolderComponent holder;
    public string itemName;
    public EcsEntity entity;
}
