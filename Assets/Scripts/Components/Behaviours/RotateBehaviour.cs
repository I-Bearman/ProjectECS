using Assets.Scripts.Components.Interfaces;
using UnityEngine;

public class RotateBehaviour : MonoBehaviour, IBehaviour
{
    private CharacterHealth character;
    
    private void Start()
    {
        character = FindObjectOfType<CharacterHealth>();
    }
    
    public float Evaluate()
    {
        if (character == null) return 0;
        return 1 / (this.gameObject.transform.position - character.transform.position).magnitude;
    }
    
    public void Behave()
    {
        transform.Rotate(Vector3.up, 10);
    }
}
