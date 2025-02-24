using Assets.Scripts.Components.Interfaces;
using Unity.Entities;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaveSystem : ComponentSystem
{
    private EntityQuery _behaveQuery;

    protected override void OnCreate()
    {
        _behaveQuery = GetEntityQuery(ComponentType.ReadOnly<AIAgent>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_behaveQuery).ForEach(
            (Entity entity, BehaviourManager manager) =>
            {
                if (manager.activeBehaviour != null)
                {
                    manager.activeBehaviour.Behave();
                }
            });
    }
}