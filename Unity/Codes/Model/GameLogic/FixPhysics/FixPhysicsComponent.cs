using BEPUphysics;
namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class FixPhysicsComponent:Entity,IAwake, IUpdate
    {
        public static FixPhysicsComponent Instance;
        public Space space;
    }
}