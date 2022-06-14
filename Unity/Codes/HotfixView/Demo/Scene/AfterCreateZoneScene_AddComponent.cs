using BEPUutilities;
using ET.EventType;

namespace ET
{
    [FriendClassAttribute(typeof(ET.BoxCollider))]
    [FriendClassAttribute(typeof(ET.BoxMoveComponent))]
    public class AfterCreateZoneScene_AddComponent : AEvent<EventType.AfterCreateZoneScene>
    {
        protected override void Run(EventType.AfterCreateZoneScene args)
        {
            Scene zoneScene = args.ZoneScene;
            zoneScene.AddComponent<UIComponent>();
            zoneScene.AddComponent<UIPathComponent>();
            zoneScene.AddComponent<UIEventComponent>();
            zoneScene.AddComponent<RedDotComponent>();
            zoneScene.AddComponent<ResourcesLoaderComponent>();

            zoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Login);

            UnitComponent unitComponent = zoneScene.AddComponent<UnitComponent>();
            BoxCollider boxCollider = null;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Unit unit = unitComponent.AddChild<Unit, int>(1001);
                    unit.Position = new UnityEngine.Vector3(i * 2 - 5, 10, j * 2 - 5);
                    Game.EventSystem.Publish(new AfterUnitCreate() { Unit = unit });
                    boxCollider = unit.AddComponent<BoxCollider>();
                    boxCollider.Init(new  Vector3(1, 1, 1), true);
                }
            }

            Unit plane = unitComponent.AddChild<Unit, int>(1002);
            BoxCollider planeboxCollider = plane.AddComponent<BoxCollider>();
            plane.Position = UnityEngine.Vector3.zero;
            planeboxCollider.Init(new Vector3(20, 1, 20), false);
            Game.EventSystem.Publish(new AfterUnitCreate() { Unit = plane });

            zoneScene.AddComponent<BoxMoveComponent>().entity = boxCollider.entity;
        }
    }
}