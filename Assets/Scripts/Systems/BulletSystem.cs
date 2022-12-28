using UnityEngine;
using Unity.Entities;

public class BulletSystem : ComponentSystem
{
    private EntityManager entityManager;
    private EntityQuery _bulletQuery;
    private float _currLifeTime;
    protected override void OnCreate()
    {
        _bulletQuery = GetEntityQuery(ComponentType.ReadOnly<BulletComponent>());
        //entityManager.CreateEntityQuery(ComponentType.ReadOnly<BulletComponent>());
    }

    protected override void OnStartRunning()
    {
        _currLifeTime = 0;
    }
    protected override void OnUpdate()
    {
        Entities.With(_bulletQuery).ForEach(
        (Entity entity, Rigidbody rigidbody, BulletComponent bulletComponent) =>
        {
            rigidbody.velocity = new Vector3(0, 0, bulletComponent.speed);
            _currLifeTime += Time.DeltaTime;
            if (_currLifeTime > bulletComponent.lifeTime)
            {
                //entityManager.DestroyEntity(entity);
                
            }
        });
    }
}
