using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
	[ObjectSystem]
	public class UiLobbyComponentSystem : AwakeSystem<UILobbyComponent>
	{
		public override void Awake(UILobbyComponent self)
		{
			self.Awake();
		}
	}
	
	public class UILobbyComponent : Component
	{
		private GameObject enterMap;
        private Button setOut;

        private Text text;

		public void Awake()
		{
			ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            enterMap = rc.Get<GameObject>("EnterMap");
            setOut = rc.Get<GameObject>("SetOut").GetComponent<Button>();
            enterMap.GetComponent<Button>().onClick.Add(this.EnterMap);
            setOut.onClick.Add(this.EnterSetOut);

			this.text = rc.Get<GameObject>("Text").GetComponent<Text>();
		}

		private void EnterMap()
		{
			MapHelper.EnterMapAsync().Coroutine();
		}
        private void EnterSetOut()
        {
            OutSpaceHelper.EnterOutSpaceAsync().Coroutine();
        }

    }
}
