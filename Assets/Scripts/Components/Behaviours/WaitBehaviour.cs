using Assets.Scripts.Components.Interfaces;
using UnityEngine;

public class WaitBehaviour : MonoBehaviour, IBehaviour
{
    public float Evaluate()
    {
        return 0.5f;
    }
 
    public void Behave()
    {
        Debug.Log("WAIT");
    }
}
