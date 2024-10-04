using System.Collections.Generic;
using UnityEngine;

public class ApplyAid : MonoBehaviour, IAbilityTarget
{
    public List<GameObject> Targets { get; set; }
    public int aid = 50;

    public void Execute()
    {
        foreach (var target in Targets)
        {
            if (target.CompareTag("Player"))
            {
                var health = target.GetComponent<CharacterHealth>();
                if (health != null) health.Health += aid;
            }
        }
    }
}