using ETModel;

namespace ETHotfix
{
	[Event(EventIdType.Init_UI_OutSpace)]
	public class LoginFinish_CreateOutSpaceUI : AEvent
	{
		public override void Run()
		{
			UI ui = UIOutSpaceFactory.Create();
			Game.Scene.GetComponent<UIComponent>().Add(ui);
		}
	}
}
