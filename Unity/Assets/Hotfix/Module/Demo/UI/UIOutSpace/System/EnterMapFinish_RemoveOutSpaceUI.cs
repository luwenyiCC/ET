using ETModel;

namespace ETHotfix
{
	[Event(EventIdType.OutSpaceFinish)]
	public class EnterMapFinish_RemoveOutSpaceUI : AEvent
	{
		public override void Run()
		{
			Game.Scene.GetComponent<UIComponent>().Remove(UIType.UIOutSpace);
			ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle(UIType.UIOutSpace.StringToAB());
		}
	}
}
