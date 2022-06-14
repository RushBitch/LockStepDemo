//using BEPUphysics.CollisionShapes.ConvexShapes;

using BEPUphysics.Entities.Prefabs;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class BoxCollider: Entity, IAwake, IUpdate
    {
        public Box entity;
    }
}