using UnityEngine;
using Unity.Entities;

public class CharacterMoveSystem : ComponentSystem
{
    private EntityQuery _moveQuery;

    protected override void OnCreate()
    {
        _moveQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(), ComponentType.ReadOnly<MoveData>(), ComponentType.ReadOnly<Transform>());
    }
    protected override void OnUpdate()
    {
        Entities.With(_moveQuery).ForEach(
            (Entity entity, Transform transform, ref InputData inputData, ref MoveData move) => 
            {
                float dx = inputData.Move.x;
                float dy = inputData.Move.y;
                if (Mathf.Abs(dx) > 0.01f || Mathf.Abs(dy) > 0.01f)
                {
                    Vector3 lookDirection = new Vector3(dx, 0, dy);
                    transform.LookAt(lookDirection * 100);
                }

                var pos = transform.position;
                pos += new Vector3(inputData.Move.x* move.Speed, 0, inputData.Move.y* move.Speed);
                transform.position = pos;
            });
    }
}
