using System.Collections.Generic;
using UnityEngine;

public class CoinComponent : MonoBehaviour, IAbilityTarget
{
    public List<GameObject> Targets { get; set; }

    public void Execute()
    {
        foreach (var target in Targets)
        {
            if (target.CompareTag("Player"))
            {
                target.GetComponent<CharacterResources>().playerResources.Gold++;
            }
        }
    }
}