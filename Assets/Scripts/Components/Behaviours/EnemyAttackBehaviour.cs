using UnityEngine;
using Assets.Scripts.Components.Interfaces;

public class EnemyAttackBehaviour : MonoBehaviour, IBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public float Evaluate()
    {
        return 0.5f;
    }

    public void Behave()
    {
        animator.SetTrigger("attack");
    }
}
