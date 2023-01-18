using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    public float speed;
    public float dashSpeed;
    public float dashDelay;

    public MonoBehaviour ShootAction;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new InputData());
        dstManager.AddComponentData(entity, new MoveData
        {
            Speed = speed,
            DashSpeed = dashSpeed,
            DashDelay = dashDelay
        });

        if (ShootAction != null && ShootAction is IAbility)
        {
            dstManager.AddComponentData(entity, new ShootData());
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
    public float DashDelay;
}

public struct ShootData : IComponentData
{

}