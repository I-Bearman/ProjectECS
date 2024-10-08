using UnityEngine;
using Unity.Entities;

public class BulletSystem : ComponentSystem
{
    private EntityQuery _bulletQuery; 

    protected override void OnCreate()
    {
        _bulletQuery = GetEntityQuery(ComponentType.ReadOnly<BulletComponent>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_bulletQuery).ForEach(
        (Entity entity, Transform transform, Rigidbody rigidbody, BulletComponent bulletComponent) =>
        {
            if (rigidbody.velocity == Vector3.zero)
            {
                rigidbody.velocity = transform.forward * bulletComponent.speed;
            }
        });
    }
}
