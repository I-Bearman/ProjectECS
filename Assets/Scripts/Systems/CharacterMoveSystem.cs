using UnityEngine;
using Unity.Entities;

public class CharacterMoveSystem : ComponentSystem
{
    private EntityQuery _moveQuery;
    private Rigidbody _rigidbody;
    private bool _isDashing = false;

    private double _dashTime = double.MinValue;
    protected override void OnCreate()
    {
        _moveQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(), ComponentType.ReadOnly<MoveData>(), ComponentType.ReadOnly<Transform>());
    }
    protected override void OnStartRunning()
    {
        Entities.With(_moveQuery).ForEach(
            (Entity entity, Rigidbody rigidbody, ref InputData inputData, ref MoveData move) =>
            {
                _rigidbody = rigidbody;
            });
    }
    protected override void OnUpdate()
    {
        Entities.With(_moveQuery).ForEach(
            (Entity entity, Transform transform, ref InputData inputData, ref MoveData move) =>
            {
                if (!_isDashing)
                {
                    Move(transform, inputData, move);
                }
                if (inputData.Dash > 0f && Time.ElapsedTime > _dashTime + move.DashDelay)
                {
                    _isDashing = true;
                    Dash(transform, move);
                }

            });
    }

    private void Move(Transform transform, InputData inputData, MoveData moveData)
    {
        if (!_isDashing)
        {
            float dx = inputData.Move.x;
            float dy = inputData.Move.y;
            if (Mathf.Abs(dx) > 0.01f || Mathf.Abs(dy) > 0.01f)
            {
                Vector3 lookDirection = new Vector3(dx, 0, dy);
                transform.LookAt(lookDirection * 100);
            }

            _rigidbody.velocity = new Vector3(inputData.Move.x, 0, inputData.Move.y) * moveData.Speed;
        }
    }
    private void Dash(Transform transform, MoveData moveData)
    {

        _dashTime = Time.ElapsedTime;
        _rigidbody.velocity = transform.forward * moveData.DashSpeed;

        if (Time.ElapsedTime > _dashTime + moveData.DashDelay)
        {
            _isDashing = false;
        }

        Debug.Log(_dashTime);
    }
}