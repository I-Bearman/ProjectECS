using System.Collections.Generic;
using UnityEngine;

public class RicochetPerkComponent : MonoBehaviour, IAbilityTarget
{
    public List<GameObject> Targets { get; set; }
    private float _tempTime;

    public void Awake()
    {
        _tempTime = Time.time;
    }

    public void Execute()
    {
        if (BulletComponent.isRicochetOn)
        {
            foreach (var target in Targets)
            {
                if (target.CompareTag("Wall"))
                {
                    if (_tempTime + 0.1f < Time.time)
                    {
                        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
                        rigidbody.velocity = Vector3.Reflect(rigidbody.velocity.normalized, target.transform.position.normalized) * rigidbody.velocity.magnitude;
                        _tempTime = Time.time;
                    }
                }
            }
        }
    }
}
