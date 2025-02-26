using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour, IAbilityTarget
{
    public List<GameObject> Targets { get; set; }
    public int damage = 10;

    private float _tempTime;

    public void Awake()
    {
        _tempTime = Time.time;
    }

    public void Execute()
    {
        if (_tempTime + 0.5f < Time.time) //задержка в случае выстрела
            foreach (var target in Targets)
            {
                var health = target.GetComponent<CharacterHealth>();
                if (health != null) health.Health -= damage;
                _tempTime = Time.time;
            }
    }
}