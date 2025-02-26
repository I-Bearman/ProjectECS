using UnityEngine;
using Unity.Entities;
using UnityEngine.AI;

public class EnemySystem : ComponentSystem
{
    private EntityQuery _enemyQuery;
    private EntityQuery _heroQuery;

    private NavMeshAgent navMeshAgent;

    protected override void OnCreate()
    {
        _enemyQuery = GetEntityQuery(ComponentType.ReadOnly<EnemyComponent>());
        _heroQuery = GetEntityQuery(ComponentType.ReadOnly<CharacterHealth>());
    }

    protected override void OnStartRunning()
    {
        Entities.With(_enemyQuery).ForEach(
        (Entity entity, Transform transform) =>
        {
            navMeshAgent = transform.GetComponent<NavMeshAgent>();
        });

        SetDestinationForEnemy();
    }

    protected override void OnUpdate()
    {
        Entities.With(_enemyQuery).ForEach(
        (Entity entity, Animator animator, NavMeshAgent navMeshAgent) =>
        {
            animator.SetFloat("velocity", navMeshAgent.velocity.magnitude);
        });

        SetDestinationForEnemy();
    }

    private void SetDestinationForEnemy()
    {
        Entities.With(_heroQuery).ForEach(
        (Entity entity, Transform transform) =>
        {
            navMeshAgent.SetDestination(transform.position);
        });
    }
}
