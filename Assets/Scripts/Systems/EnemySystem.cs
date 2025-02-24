using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.AI;

public class EnemySystem : ComponentSystem
{
    private EntityQuery _enemyQuery;
    private EntityQuery _heroQuery;
    private Transform _heroTransform;
    protected override void OnCreate()
    {
        _enemyQuery = GetEntityQuery(ComponentType.ReadOnly<EnemyComponent>());
        _heroQuery = GetEntityQuery(ComponentType.ReadOnly<CharacterHealth>());


    }

    protected override void OnUpdate()
    {

        Entities.With(_heroQuery).ForEach(
(Entity entity, Transform transform) =>
{
    _heroTransform = transform;
});

        Entities.With(_enemyQuery).ForEach(
        (Entity entity, NavMeshAgent navMeshAgent) =>
        {
            navMeshAgent.destination = _heroTransform.position;
        });


        Entities.With(_enemyQuery).ForEach(
        (Entity entity, Animator animator, Rigidbody rigidbody) =>
        {
            animator.SetFloat("velocity", rigidbody.velocity.magnitude);
        });
    }
}
