using Unity.Entities;
using UnityEngine;

public class ShootAbility : MonoBehaviour, IComponentData, IAbility
{
    public GameObject bullet;
    public float shootDelay;

    private float _shootTime = float.MinValue;
    public void Execute()
    {
        if (Time.time < _shootTime + shootDelay) return;

        _shootTime = Time.time;

        if(bullet != null)
        {
            var t = transform;
            var newBullet = Instantiate(bullet, t.position + bullet.transform.position, t.rotation);
        }
        else
        {
            Debug.LogError("[SHOOT ABILITY] No bullet prefab link!");
        }
    }
}
