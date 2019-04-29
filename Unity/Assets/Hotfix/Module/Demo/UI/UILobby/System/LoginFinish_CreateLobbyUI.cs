using ETModel;

namespace ETHotfix
{
	[Event(EventIdType.Init_UI_Lobby)]
	public class LoginFinish_CreateLobbyUI: AEvent
	{
		public override void Run()
		{
			UI ui = UILobbyFactory.Create();
			Game.Scene.GetComponent<UIComponent>().Add(ui);
		}
	}
}
