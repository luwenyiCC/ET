using ETModel;
namespace ETHotfix
{
    [Event(EventIdType.RegisterAndLoginFinish)]
    public class RegisterAndLoginFinish_RemoveRegisterAndLoginUI : AEvent
    {
        public override void Run()
        {
            Game.Scene.GetComponent<UIComponent>().Remove(UIType.UIRegisterAndLogin);
            ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle(UIType.UIRegisterAndLogin.StringToAB());
        }
    }
}