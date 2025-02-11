using Assets.Scripts;
using UnityEngine;

public class ShootAbility : MonoBehaviour, IAbility
{
    public GameObject bullet;
    public float shootDelay;

    private float _shootTime = float.MinValue;
    public PlayerStats stats;

    public void Start()
    {
        var jsonString = PlayerPrefs.GetString("Stats");
        if (!jsonString.Equals(string.Empty, System.StringComparison.Ordinal))
        {
            stats = JsonUtility.FromJson<PlayerStats>(jsonString);
        }
        else
        {
            stats = new PlayerStats();
        }
    }
    public void Execute()
    {
        if (Time.time < _shootTime + shootDelay) return;

        _shootTime = Time.time;

        if(bullet != null)
        {
            var t = transform;
            var newBullet = Instantiate(bullet, t.position + bullet.transform.position, t.rotation);
            stats.shotsCount++;
        }
        else
        {
            Debug.LogError("[SHOOT ABILITY] No bullet prefab link!");
        }
    }
}
