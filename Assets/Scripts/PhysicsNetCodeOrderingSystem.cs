using Unity.NetCode;
using Unity.Physics.Systems;
using Unity.Entities;
using Unity.Jobs;


[UpdateBefore(typeof(BuildPhysicsWorld))]
[UpdateAfter(typeof(GhostSimulationSystemGroup))]
public class PhysicsNetCodeOrderingSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        return inputDeps;
    }
}