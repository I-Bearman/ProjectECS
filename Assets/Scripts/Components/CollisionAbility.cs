using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine.Tilemaps;
using DefaultNamespace;

public class CollisionAbility : MonoBehaviour, IConvertGameObjectToEntity, IAbility
{
    public Collider Collider;

    public List<MonoBehaviour> collisionsActions = new List<MonoBehaviour>();
    public List<IAbilityTarget> collisionActionsAbilities = new List<IAbilityTarget>();

    [HideInInspector] public List<Collider> collisions;


    private void Start()
    {
        foreach (var action in collisionsActions)
        {
            if (action is IAbilityTarget ability)
            {
                collisionActionsAbilities.Add(ability);
            }
            else
            {
                Debug.Log("Collision action must derive from IAbility!!!");
            }
        }
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        float3 position = gameObject.transform.position;
        switch (Collider)
        {
            case SphereCollider sphere:
                sphere.ToWorldSpaceSphere(out var sphereCenter, out var sphereRadius);
                dstManager.AddComponentData(entity, new ActorColliderData
                {
                    ColliderType = (Tile.ColliderType)ColliderType.Sphere,
                    SphereCenter = sphereCenter - position,
                    SphereRadius = sphereRadius,
                    initialTakeOff = true
                });
                break;
            case CapsuleCollider capsule:
                capsule.ToWorldSpaceCapsule(out var capsuleStart, out var capsuleEnd, out var capsuleRadius);
                dstManager.AddComponentData(entity, new ActorColliderData
                {
                    ColliderType = (Tile.ColliderType)ColliderType.Capsule,
                    CapsuleStart = capsuleStart - position,
                    CapsuleEnd = capsuleEnd - position,
                    CapsuleRadius = capsuleRadius,
                    initialTakeOff = true
                });
                break;
            case BoxCollider box:
                box.ToWorldSpaceBox(out var boxCenter, out var boxHalfExtents, out var boxOrientation);
                dstManager.AddComponentData(entity, new ActorColliderData
                {
                    ColliderType = (Tile.ColliderType)ColliderType.Box,
                    BoxCenter = boxCenter - position,
                    BoxHalfExtents = boxHalfExtents,
                    BoxOrientation = boxOrientation,
                    initialTakeOff = true
                });
                break;
        }
        Collider.enabled = false;
    }

    public void Execute()
    {
        foreach (var action in collisionActionsAbilities)
        {
            action.Targets = new List<GameObject>();
            collisions.ForEach(c =>
            {
                if (c != null)
                    action.Targets.Add(c.gameObject);
            });
            action.Execute();
        }
    }

    public struct ActorColliderData : IComponentData
    {
        public Tile.ColliderType ColliderType;
        public float3 SphereCenter;
        public float SphereRadius;
        public float3 CapsuleStart;
        public float3 CapsuleEnd;
        public float CapsuleRadius;
        public float3 BoxCenter;
        public float3 BoxHalfExtents;
        public quaternion BoxOrientation;
        public bool initialTakeOff;
    }

    public enum ColliderType
    {
        Sphere = 0,
        Capsule = 1,
        Box = 2
    }
}
