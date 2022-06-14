using UnityEngine;
using Quaternion = BEPUutilities.Quaternion;
using Vector3 = BEPUutilities.Vector3;

namespace ET
{
    public class BoxMoveComponentUpdateSystem:UpdateSystem<BoxMoveComponent>
    {
        public override void Update(BoxMoveComponent self)
        {
            Vector3 vector3 = new Vector3(0, 0, 0);
            if (Input.GetKey(KeyCode.W))
            {
                vector3.Z += 1;
            }
            if(Input.GetKey(KeyCode.S))
            {
                vector3.Z -= 1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                vector3.X -= 1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                vector3.X += 1;
            }

            if (vector3.X== 0 && vector3.Z == 0)
            {
                return;
            }
            self.entity.LinearVelocity = vector3;
            self.entity.Orientation = Quaternion.CreateFromYawPitchRoll((float)vector3.X,(float)vector3.Y,(float)vector3.Z);
        }
    }
}