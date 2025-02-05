using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class RicochetPerkComponent : MonoBehaviour, IComponentData, IAbilityTarget
{
    public List<GameObject> Targets { get; set; }

    public void Execute()
    {
        if (BulletComponent.isRicochetOn)
        {
            foreach (var target in Targets)
            {
                if (target.CompareTag("Wall"))
                {
                    Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
                    target.GetComponent<Collider>();
                    rigidbody.velocity = Vector3.Reflect(rigidbody.velocity, transform.right).normalized * rigidbody.velocity.magnitude;
                }
            }
        }
    }
}
