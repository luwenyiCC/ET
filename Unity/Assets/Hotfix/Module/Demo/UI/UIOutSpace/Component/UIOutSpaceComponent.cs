
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
	[ObjectSystem]
	public class UIOutSpaceComponentSystem : AwakeSystem<UIOutSpaceComponent>
	{
		public override void Awake(UIOutSpaceComponent self)
		{
			self.Awake();
		}
	}
	
	public class UIOutSpaceComponent : Component
	{
		private GameObject exit;

		public void Awake()
		{
			ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            exit = rc.Get<GameObject>("Exit");
            exit.GetComponent<Button>().onClick.Add(this.Btn_Exit);
		}

		private void Btn_Exit()
		{
            Debug.Log("返回基地");
			//MapHelper.EnterMapAsync().Coroutine();
		}
    }
}
