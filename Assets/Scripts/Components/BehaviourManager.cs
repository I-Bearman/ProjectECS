using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Components.Interfaces;
using UnityEngine;
using Unity.Entities;

public class BehaviourManager : MonoBehaviour, IConvertGameObjectToEntity
{
    public List<MonoBehaviour> behaviours;
    public IBehaviour activeBehaviour;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponent<AIAgent>(entity);
    }
}

public struct AIAgent: IComponentData
{
}