using UnityEngine;
using Assets.Scripts.Components.Interfaces;
using UnityEngine.AI;

public class EnemyWalkBehaviour : MonoBehaviour, IBehaviour
{
    private CharacterHealth hero;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        hero = FindObjectOfType<CharacterHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(hero.transform.position);
    }

    public float Evaluate()
    {
        if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance + 0.1f)
        {
            return 1;
        }
       return 0;
    }

    public void Behave()
    {
    }
}
