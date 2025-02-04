using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;

public class UserInputData : Baker<MonoBehaviour>
{
    public float speed;
    public float dashSpeed;
    [Tooltip("time of self dash")]
    public float dashTime;
    [Tooltip("time between dashes")]
    public float dashDelay;

    public MonoBehaviour ShootAction;

    [System.Obsolete]
    public override void Bake(MonoBehaviour authoring)
    {
        AddComponent(new InputData());
        AddComponent(new MoveData
        {
            Speed = speed,
            DashSpeed = dashSpeed,
            DashTime = dashTime,
            DashDelay = dashDelay
        });

        if (ShootAction != null && ShootAction is IAbility)
        {
            AddComponent(new ShootData());
        }
    }
}

public struct InputData : IComponentData
{
    public float2 Move;
    public float Shoot;
    public float Dash;
}

public struct MoveData : IComponentData
{
    public float Speed;
    public float DashSpeed;
    public float DashTime; //time of self dash
    public float DashDelay; //time between dashes
}

public struct ShootData : IComponentData
{

}