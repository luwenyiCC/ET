using System;
using System.Net;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
	[ObjectSystem]
	public class UiLoginComponentSystem : AwakeSystem<UILoginComponent>
	{
		public override void Awake(UILoginComponent self)
		{
			self.Awake();
		}
	}
	
	public class UILoginComponent: Component
	{
		private InputField account;
        private InputField password;
        private GameObject loginBtn;
        private GameObject reighterBtn;
		public void Awake()
		{
			ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
			loginBtn = rc.Get<GameObject>("LoginBtn");
			loginBtn.GetComponent<Button>().onClick.Add(OnLogin);
            this.account = rc.Get<GameObject>("Account").GetComponent<InputField>();
            this.password = rc.Get<GameObject>("Password").GetComponent<InputField>();
            this.reighterBtn = rc.Get<GameObject>("RegisterBtn");
            reighterBtn.GetComponent<Button>().onClick.Add(OnRegister);
            
		}

		public void OnLogin()
		{
			LoginHelper.OnLoginAsync(this.account.text, this.password.text).Coroutine();
		}
        public void OnRegister()
        {
            Game.EventSystem.Run(EventIdType.InitRegisterAndLogin);
            Game.EventSystem.Run(EventIdType.LoginFinish);
        }
	}
}
