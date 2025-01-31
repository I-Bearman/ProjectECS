using System.Collections.Generic;
using UnityEngine;

public class ApplyDamage : MonoBehaviour, IAbilityTarget
{
    public List<GameObject> Targets { get; set; }
    public int damage = 10;

    private float _createTime;

    public void Awake()
    {
        _createTime = Time.time;
    }

    public void Execute()
    {
        if (_createTime + 0.3f < Time.time) //задержка в случае выстрела
        foreach (var target in Targets)
        {
            var health = target.GetComponent<CharacterHealth>();
            if (health != null) health.Health -= damage;
        }
    }
}
