using ETModel;
namespace ETHotfix
{
    [Event(EventIdType.InitRegisterAndLogin)]
    public class InitSceneStart_CreateRegisterAndLoginUI : AEvent
    {
        public override void Run()
        {
            UI ui = UIRegisterAndLoginFactory.Create();
            Game.Scene.GetComponent<UIComponent>().Add(ui);
        }
    }
}