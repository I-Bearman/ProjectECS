using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetPerk : MonoBehaviour, IAbilityTarget
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
