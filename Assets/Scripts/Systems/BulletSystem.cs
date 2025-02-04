using UnityEngine;
using Unity.Entities;

public class BulletSystem : SystemBase
{
    private EntityQuery _bulletQuery; 

    protected override void OnCreate()
    {
        _bulletQuery = GetEntityQuery(ComponentType.ReadOnly<BulletComponent>());
    }

    protected override void OnUpdate()
    {
        Entities.WithAll<BulletComponent>().ForEach(
        (Entity entity, Transform transform, Rigidbody rigidbody, BulletComponent bulletComponent) =>
        {
            if (rigidbody.velocity == Vector3.zero)
            {
                rigidbody.velocity = transform.forward * bulletComponent.speed;
            }
        });
    }
}
