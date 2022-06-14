
using BEPUphysics;
using BEPUutilities;

namespace ET
{
    public class FixPhysicsAwakeComponentSystem:AwakeSystem<FixPhysicsComponent>
    {
        public override void Awake(FixPhysicsComponent self)
        {
            FixPhysicsComponent.Instance = self;
            self.space = new Space();
            self.space.ForceUpdater.Gravity = new Vector3(0,-1,0);
        }
    }
    
    public class FixPhysicsUpdateComponentSystem:UpdateSystem<FixPhysicsComponent>
    {
        public override void Update(FixPhysicsComponent self)
        {
            self.space.Update();
        }
    }
    
    public static class FixPhysicsComponentSystem
    {
        
    }
}