using ETModel;

namespace ETHotfix
{
	[Event(EventIdType.LobbyFinish)]
	public class EnterMapFinish_RemoveLobbyUI: AEvent
	{
		public override void Run()
		{
			Game.Scene.GetComponent<UIComponent>().Remove(UIType.UILobby);
			ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle(UIType.UILobby.StringToAB());
		}
	}
}
