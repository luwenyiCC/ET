using System;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    public static class UIOutSpaceFactory
    {
        public static UI Create()
        {
	        try
	        {
				ResourcesComponent resourcesComponent = ETModel.Game.Scene.GetComponent<ResourcesComponent>();
		        resourcesComponent.LoadBundle(UIType.UIOutSpace.StringToAB());
				GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(UIType.UIOutSpace.StringToAB(), UIType.UIOutSpace);
				GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);
		        UI ui = ComponentFactory.Create<UI, string, GameObject>(UIType.UIOutSpace, gameObject, false);

				ui.AddComponent<UIOutSpaceComponent>();
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