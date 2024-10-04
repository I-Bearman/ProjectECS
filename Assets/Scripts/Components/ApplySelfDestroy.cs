using System.Collections.Generic;
using UnityEngine;

public class ApplySelfDestroy : MonoBehaviour, IAbilityTarget
{
    public List<GameObject> Targets { get; set; }

    public void Execute()
    {
        foreach (var target in Targets)
        {
            if (target.CompareTag("Player"))
                Destroy(gameObject);
        }
    }
}