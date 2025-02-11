using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public Settings settings;
    public int Health;
    public ShootAbility shootAbility;

    public Text HealthText;

    private int _health;

    private void Start()
    {
        Health = settings.HeroHealth;
        _health = Health;
    }

    private void Awake()
    {
        ChangeTitleHealth();
    }

    private void Update()
    {
        ChangeTitleHealth();
    }

    private void ChangeTitleHealth()
    {
        if (_health != Health)
        {
            HealthText.text = $"Health: {Health}";
            WriteStatistics();
            _health = Health;
        }
    }

    private void WriteStatistics()
    {
        var jsonString = JsonUtility.ToJson(shootAbility.stats);
        Debug.Log(jsonString);
        PlayerPrefs.SetString("Stats", jsonString);
        PlayerPrefs.Save();
    }
}