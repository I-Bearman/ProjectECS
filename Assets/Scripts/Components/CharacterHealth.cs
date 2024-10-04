using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public int Health = 100;
    public Text HealthText;

    private int _health;

    private void Start()
    {
        _health = Health;
    }

    private void Update()
    {
        if (_health != Health)
        {
            HealthText.text = $"Health: {Health}";
            _health = Health;
        }
    }
}
