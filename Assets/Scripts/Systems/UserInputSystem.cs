using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInputSystem : SystemBase, PlayerInputAction.IPlayerActions
{
    private EntityQuery _movementQuery;

    private Vector2 _moveInput;
    private float _shootInput;
    private float _dashInput;

    protected override void OnCreate()
    {
        _movementQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
        
        var inputAction = new PlayerInputAction();
        inputAction.Player.SetCallbacks(this);
        inputAction.Player.Enable();
    }

    public void OnMove(InputAction.CallbackContext context) => _moveInput = context.ReadValue<Vector2>();

    public void OnShoot(InputAction.CallbackContext context) => _shootInput = context.ReadValue<float>();

    public void OnDash(InputAction.CallbackContext context) => _dashInput = context.ReadValue<float>();

    protected override void OnUpdate()
    {
        Entities.WithAll<InputData>().ForEach(
            (Entity entity, ref InputData inputData) => 
            {
                inputData.Move = _moveInput;
                inputData.Shoot = _shootInput;
                inputData.Dash = _dashInput;
            });
    }
}
