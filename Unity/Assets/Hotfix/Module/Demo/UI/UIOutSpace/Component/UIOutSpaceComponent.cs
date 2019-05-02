
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
        /// <summary>
        /// 激光镭射
        /// </summary>
        private Button Laser;
        /// <summary>
        /// 护盾撞击
        /// </summary>
        private Button Shield;
        /// <summary>
        /// 弹幕齐射
        /// </summary>
        private Button Barrage;

        public void Awake()
		{
			ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            exit = rc.Get<GameObject>("Exit");
            exit.GetComponent<Button>().onClick.Add(this.Btn_Exit);

            Laser = rc.Get<GameObject>("Laser").GetComponent<Button>();
            Laser.onClick.Add(this.Btn_Exit);

            Shield = rc.Get<GameObject>("Shield").GetComponent<Button>();
            Shield.onClick.Add(this.Btn_Exit);

            Barrage = rc.Get<GameObject>("Barrage").GetComponent<Button>();
            Barrage.onClick.Add(this.Btn_Exit);
        }
        private void Btn_Laser()
        {
            Frame_Joystick joystick= new Frame_Joystick();
            joystick.X = 1;
            ETModel.SessionComponent.Instance.Session.Send(joystick);
            Debug.Log("Btn_Laser");
            //MapHelper.EnterMapAsync().Coroutine();
        }
        private void Btn_Shield()
        {
            Debug.Log("Btn_Shield");
            //MapHelper.EnterMapAsync().Coroutine();
        }
        private void Btn_Barrage()
        {
            Debug.Log("Btn_Barrage");
            //MapHelper.EnterMapAsync().Coroutine();
        }
        private void Btn_Exit()
		{
            Debug.Log("返回基地");
			//MapHelper.EnterMapAsync().Coroutine();
		}
    }
}
