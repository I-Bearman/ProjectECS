using Unity.Entities;
using UnityEngine;

public class BulletComponent : IComponentData
{
    public float speed;
    public static bool isRicochetOn = false;
}
