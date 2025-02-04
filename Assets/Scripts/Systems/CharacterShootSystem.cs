using Unity.Entities;

public class CharacterShootSystem : SystemBase
{
    private EntityQuery _shootQuery;

    protected override void OnCreate()
    {
        _shootQuery = GetEntityQuery(
            ComponentType.ReadOnly<InputData>(), 
            ComponentType.ReadOnly<ShootData>(),
            ComponentType.ReadOnly<UserInputData>()
            );
    }
    protected override void OnUpdate()
    {
        Entities.WithAll<ShootData>().ForEach(
            (Entity entity, UserInputData inputData, ref InputData input, ref MoveData move) => 
            {
                if(input.Shoot > 0f && inputData.ShootAction != null && inputData.ShootAction is IAbility ability)
                {
                    ability.Execute();
                }
            });
    }
}