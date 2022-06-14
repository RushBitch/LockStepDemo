namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class BoxMoveComponent:Entity, IUpdate, IAwake
    {
        public BEPUphysics.Entities.Entity entity;
    }
}