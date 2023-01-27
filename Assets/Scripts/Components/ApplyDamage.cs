using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour, IAbilityTarget
{
    public List<GameObject> Targets { get; set; }
    public int damage = 10;

    public void Execute()
    {
        foreach (var target in Targets)
        {
            var health = target.GetComponent<CharacterHealth>();
            if (health != null) health.Health -= damage;
        }
    }
}
