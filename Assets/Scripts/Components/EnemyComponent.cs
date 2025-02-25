using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyComponent : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        animator.SetFloat("velocity", navMeshAgent.velocity.magnitude);
    }
}
