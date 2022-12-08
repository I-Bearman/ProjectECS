using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;

public class UserInputData: MonoBehaviour, IConvertGameObjectToEntity
{
    public float speed;

    public MonoBehaviour ShootAction;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData<InputData>(entity, new InputData());
        dstManager.AddComponentData<MoveData>(entity, new MoveData() 
        { 
            Speed = speed / 100 
        });
    }
}

public struct InputData : IComponentData
{
    public float2 Move;
    public float Shoot;
}

public struct MoveData : IComponentData
{
    public float Speed;
}

public struct ShootData : IComponentData
{
    
}