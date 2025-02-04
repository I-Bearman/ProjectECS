using UnityEngine;
using Unity.Entities;


public class DestroySystem : SystemBase
{
    private EntityQuery _selfDestoyableQuery;

    protected override void OnCreate()
    {
        _selfDestoyableQuery = GetEntityQuery(ComponentType.ReadOnly<SelfDestroyable>());
    }

    protected override void OnUpdate()
    {
        Entities.WithAll<SelfDestroyable>().ForEach(
        (Entity entity, SelfDestroyable selfDestroyable) =>
        {
            if (selfDestroyable.canBeDestroy == true)
            {
                Object.Destroy(selfDestroyable.gameObject);
                EntityManager.DestroyEntity(entity);
            }
        });
    }
}
