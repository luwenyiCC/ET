using UnityEngine;
using ETModel;
using UnityEngine.UI;

namespace ETHotfix
{
    [ObjectSystem]
    public class UIRegisterAndLoginComponentSystem : AwakeSystem<UIRegisterAndLoginComponent>
    {
        public override void Awake(UIRegisterAndLoginComponent self)
        {
            self.Awake();
        }
    }

    public class UIRegisterAndLoginComponent : Component
    {
        private GameObject account;
        private GameObject pwd;//密码
        private GameObject confirm;
        private GameObject button;
        private GameObject backLogin;
        public void Awake()
        {
            Debug.Log("UIRegisterAndLoginComponent Awake");
            ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            button = rc.Get<GameObject>("Btn");
            button.GetComponent<Button>().onClick.Add(OnButtonClick);
            backLogin = rc.Get<GameObject>("BackLogin");
            backLogin.GetComponent<Button>().onClick.Add(OnClick_BackLogin);
            account = rc.Get<GameObject>("Account");
            pwd = rc.Get<GameObject>("Password");
            confirm = rc.Get<GameObject>("Confirm");
        }
        public void OnButtonClick()
        {
            Debug.Log("UIRegisterAndLoginComponent OnButtonClick");

            string local_account = this.account.GetComponent<InputField>().text;
            string local_password = this.pwd.GetComponent<InputField>().text;
            string local_confirmd = this.confirm.GetComponent<InputField>().text;
            if (local_account.Length < 6)
            {
                Debug.Log("用户名最少六个字");
                return;
            }
            if (local_confirmd != local_password)
            {
                Debug.Log("两次输入的密码不一致");
                return;
            }
            RegisterAndLoginHelper.OnRegisterAndLoginAsync(local_account, local_password).Coroutine();//发送请求
        }
        public void OnClick_BackLogin()
        {
            Game.EventSystem.Run(EventIdType.InitSceneStart);//打开登录UI事件
            Game.EventSystem.Run(EventIdType.RegisterAndLoginFinish);//关闭 登录并注册UI事件

        }
    }
}

