using UnityEngine;

namespace ET
{
    [FriendClass(typeof(GlobalComponent))]
    public class AfterUnitCreate_CreateUnitView: AEvent<EventType.AfterUnitCreate>
    {
        protected override void Run(EventType.AfterUnitCreate args)
        {
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            if (args.Unit.Config.Id == 1001)
            {
                GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
                GameObject prefab = bundleGameObject.Get<GameObject>("Cube1");
	        
                GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
                go.transform.position = args.Unit.Position;
                args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            }
            else if(args.Unit.Config.Id == 1002)
            {
                GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Unit.unity3d", "Unit");
                GameObject prefab = bundleGameObject.Get<GameObject>("Cube");
	        
                GameObject go = UnityEngine.Object.Instantiate(prefab, GlobalComponent.Instance.Unit, true);
                go.transform.position = args.Unit.Position;
                args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            }
            
            //args.Unit.AddComponent<AnimatorComponent>();
        }
    }
}