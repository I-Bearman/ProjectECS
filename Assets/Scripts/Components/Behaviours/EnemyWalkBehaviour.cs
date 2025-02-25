using UnityEngine;
using Assets.Scripts.Components.Interfaces;
using UnityEngine.AI;

public class EnemyWalkBehaviour : MonoBehaviour, IBehaviour
{
    private CharacterHealth hero;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private void Start()
    {
        hero = FindObjectOfType<CharacterHealth>();
        animator = GetComponent<Animator>();
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
        navMeshAgent.SetDestination(hero.transform.position);
    }
}
