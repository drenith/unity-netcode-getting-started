using Unity.Entities;
using Unity.NetCode;
using Unity.Transforms;
using Unity.Physics;
using Unity.Mathematics;

[UpdateInGroup(typeof(GhostPredictionSystemGroup))]
public class MoveCubeSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        var group = World.GetExistingSystem<GhostPredictionSystemGroup>();
        var tick = group.PredictingTick;
        var deltaTime = Time.DeltaTime;
        Entities.ForEach((DynamicBuffer<CubeInput> inputBuffer, ref Translation trans, ref PhysicsVelocity vel, ref PredictedGhostComponent prediction) =>
        {
            if (!GhostPredictionSystemGroup.ShouldPredict(tick, prediction))
                return;
            CubeInput input;
            inputBuffer.GetDataAtTick(tick, out input);
            if (input.horizontal > 0)
                vel.Linear.x += deltaTime * 10;
            if (input.horizontal < 0)
                vel.Linear.x -= deltaTime * 10;
            if (input.vertical > 0)
                vel.Linear.z += deltaTime * 10;
            if (input.vertical < 0)
                vel.Linear.z -= deltaTime * 10;
            if (input.up > 0)
                vel.Linear.y += deltaTime * 10;
            if (input.reset)
                trans.Value.xyz = new float3(0, 3, 0);
        });
    }
}