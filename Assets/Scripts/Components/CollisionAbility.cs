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
    public List<Collider> collisions;

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
        Debug.Log("HIT");
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
