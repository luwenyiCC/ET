using System;
using ETModel;

namespace ETHotfix
{
    public static class OutSpaceHelper
    {
        public static async ETVoid EnterOutSpaceAsync()
        {
            try
            {
                // 加载Unit资源
                ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
                await resourcesComponent.LoadBundleAsync($"unit.unity3d");

                // 加载场景资源
                await ETModel.Game.Scene.GetComponent<ResourcesComponent>().LoadBundleAsync("outspace.unity3d");
                // 切换到outspace场景
                using (SceneChangeComponent sceneChangeComponent = ETModel.Game.Scene.AddComponent<SceneChangeComponent>())
                {
                    await sceneChangeComponent.ChangeSceneAsync(SceneType.OutSpace);
                }
				
                G2C_EnterOutSpace g2CEnterMap = await ETModel.SessionComponent.Instance.Session.Call(new C2G_EnterOutSpace()) as G2C_EnterOutSpace;
                PlayerComponent.Instance.MyPlayer.UnitId = g2CEnterMap.ShipId;
				
                Game.Scene.AddComponent<OutSpaceComponent>();

                Game.EventSystem.Run(EventIdType.LobbyFinish);
                Game.EventSystem.Run(EventIdType.Init_UI_OutSpace);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }	
        }
    }
}