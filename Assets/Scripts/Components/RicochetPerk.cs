using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class RicochetPerk : IComponentData, IAbilityTarget
{
    public List<GameObject> Targets { get; set; }

    public void Execute()
    {
        foreach (var target in Targets)
        {
            if (target.CompareTag("Player"))
            {
                BulletComponent.isRicochetOn = true;
            }
        }
    }
}
