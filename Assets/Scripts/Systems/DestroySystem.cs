using UnityEngine;
using Unity.Entities;


public class DestroySystem : ComponentSystem
{
    private EntityQuery _selfDestoyableQuery;

    protected override void OnCreate()
    {
        _selfDestoyableQuery = GetEntityQuery(ComponentType.ReadOnly<SelfDestroyable>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_selfDestoyableQuery).ForEach(
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
