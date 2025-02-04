using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : IComponentData
{
    public int Health = 100;
    public Text HealthText;

    private int _health;

    private void Start()
    {
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
            _health = Health;
        }
    }
}
