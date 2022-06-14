using BEPUphysics.Entities.Prefabs;
using BEPUutilities;

namespace ET
{
    public class BoxColliderAwakeSystem: AwakeSystem<BoxCollider>
    {
        public override void Awake(BoxCollider self)
        {
        }
    }

    public class BoxColliderUpdateSystem: UpdateSystem<BoxCollider>
    {
        public override void Update(BoxCollider self)
        {
            self.GetParent<Unit>().Position =
                    new UnityEngine.Vector3((float) self.entity.Position.X, (float) self.entity.Position.Y, (float) self.entity.Position.Z);
            self.GetParent<Unit>().Rotation = new UnityEngine.Quaternion((float) self.entity.Orientation.X, (float) self.entity.Orientation.Y,
                (float) self.entity.Orientation.Z, (float) self.entity.Orientation.W);
        }
    }

    [FriendClassAttribute(typeof (ET.BoxCollider))]
    [FriendClassAttribute(typeof (ET.FixPhysicsComponent))]
    public static class BoxColliderSystem
    {
        public static void Init(this BoxCollider self, Vector3 scale, bool needRigibody)
        {
            if (needRigibody)
            {
                // List<CompoundChildData> list = new List<CompoundChildData>();
                // var child = new CompoundChildData
                // {
                //     
                //     Entry = new CompoundShapeEntry(new BoxShape(scale.x, scale.y, scale.z), new RigidTransform(new FixVector3(self.GetParent<Unit>().Position.x, self.GetParent<Unit>().Position.y,
                //         self.GetParent<Unit>().Position.z), new FixQuaternion(self.GetParent<Unit>().Rotation.x, self.GetParent<Unit>().Rotation.y,
                //         self.GetParent<Unit>().Rotation.z, self.GetParent<Unit>().Rotation.w))),
                //     Tag = self,
                //     CollisionRules = new CollisionRules {Personal= CollisionRule.Normal },
                //
                // };
                // child.Tag = self;
                //
                //
                // list.Add(child);
                // self.entity = new CompoundBody(list,new FixVector3(self.GetParent<Unit>().Position.x, self.GetParent<Unit>().Position.y,
                //     self.GetParent<Unit>().Position.z));
                // //self.entity = new BEPUphysics.Entities.Entity(new BoxShape(scale.x, scale.y, scale.z));
                // self.entity.CollisionInformation.CollisionRules.Personal = CollisionRule.Defer;
                // if (self.entity is IBroadPhaseEntryOwner entry)
                // {
                //     entry.Entry.Tag = self;
                // }
                // self.entity.Mass = 1f;
                //  self.entity.Material.StaticFriction = 1f;
                //  self.entity.Material.KineticFriction = 1f;
                //  self.entity.Material.Bounciness = 0;
                //  self.entity.Tag = self;
                //  // self.entity.AngularDamping = 0f;
                //  // self.entity.AngularVelocity = new BEPUutilities.Vector3(1,1,1);
                //  self.entity.Position = new FixVector3(self.GetParent<Unit>().Position.x, self.GetParent<Unit>().Position.y,
                //     self.GetParent<Unit>().Position.z);
                // ;
                // self.entity.Rotation = new FixQuaternion(self.GetParent<Unit>().Rotation.x, self.GetParent<Unit>().Rotation.y,
                //     self.GetParent<Unit>().Rotation.z, self.GetParent<Unit>().Rotation.w);
                self.entity = new Box(new Vector3(self.GetParent<Unit>().Position.x, self.GetParent<Unit>().Position.y,
                self.GetParent<Unit>().Position.z),1,1,1,1);
                
            }
            else
            {
                self.entity = new Box(Vector3.Zero, 30, 1, 30);
                //self.entity = new QTool.BEPUphysics.Entities.Entity(new BoxShape(scale.x, scale.y, scale.z));
                self.entity.Position = new Vector3(self.GetParent<Unit>().Position.x, self.GetParent<Unit>().Position.y,
                    self.GetParent<Unit>().Position.z);
                self.entity.Orientation = new Quaternion(self.GetParent<Unit>().Rotation.x, self.GetParent<Unit>().Rotation.y,
                    self.GetParent<Unit>().Rotation.z, self.GetParent<Unit>().Rotation.w);
            }
            FixPhysicsComponent.Instance.space.Add(self.entity);
        }
    }
}