using System.Collections;
using UnityEngine;
using Unity.Entities;


public class DogMoveSystem : ComponentSystem
{
    private EntityQuery _query;

    protected override void OnCreate()
    {
        _query = GetEntityQuery(ComponentType.ReadOnly<DogMoveComponent>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_query).ForEach((Entity entity, Transform transform, DogMoveComponent dogMove) =>
        {
            var p = transform.position;
            p.y += dogMove.moveSpeed / 1000;
            transform.position = p;
        }
        );
    }
}