using Unity.Entities;
using Unity.Transforms;
using Unity.Jobs;
using Unity.Physics;
using Unity.Mathematics;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class MovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Translation position, ref PhysicsVelocity vel, in MoveData moveData) => {
            if(moveData.reset) {
                position.Value.xyz = new float3(0, 2.91f, 0);
            }
            
            float3 newVel = vel.Linear.xyz;
            
            newVel += new float3(moveData.direction.x, moveData.direction.y, moveData.direction.z) * 10 * deltaTime;

            vel.Linear.xyz = newVel;
        }).Run();

        return default;
    }
}
