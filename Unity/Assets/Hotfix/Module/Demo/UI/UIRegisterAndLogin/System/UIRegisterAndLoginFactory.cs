using System;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    public static class UIRegisterAndLoginFactory
    {
        public static UI Create()
        {
	        try
	        {
				ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
				resourcesComponent.LoadBundle(UIType.UIRegisterAndLogin.StringToAB());
				GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(UIType.UIRegisterAndLogin.StringToAB(), UIType.UIRegisterAndLogin);
				GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);

		        UI ui = ComponentFactory.Create<UI, string, GameObject>(UIType.UIRegisterAndLogin, gameObject, false);

				ui.AddComponent<UIRegisterAndLoginComponent>();
				return ui;
	        }
	        catch (Exception e)
	        {
				Log.Error(e);
		        return null;
	        }
		}
    }
}