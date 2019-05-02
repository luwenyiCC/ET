using System;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class OutSpaceComponentAwakeSystem : AwakeSystem<OutSpaceComponent>
    {
	    public override void Awake(OutSpaceComponent self)
	    {
		    self.Awake();
	    }
    }

	[ObjectSystem]
	public class OutSpaceComponentUpdateSystem : UpdateSystem<OutSpaceComponent>
	{
		public override void Update(OutSpaceComponent self)
		{
			self.Update();
		}
	}

	public class OutSpaceComponent : Component
    {
        public Vector3 ClickPoint;

	    //public int mapMask;

	    public void Awake()
	    {
		    //this.mapMask = LayerMask.GetMask("Map");
	    }

	    private readonly Frame_Joystick frame_Joystick = new Frame_Joystick();

        public void Update()
        {
            //if (Input.GetMouseButtonDown(1))
            //{
            //    frame_Joystick.X = 0;
            //    frame_Joystick.Y = 0;
            //    frame_Joystick.Z = 0;
            //    ETModel.SessionComponent.Instance.Session.Send(frame_Joystick);
            //    this.TestActor().Coroutine();
            //}
    //        if (Input.GetMouseButtonDown(1))
    //        {
    //            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //            RaycastHit hit;
    //         if (Physics.Raycast(ray, out hit, 1000, this.mapMask))
    //         {
    //	this.ClickPoint = hit.point;
    //          frameClickMap.X = this.ClickPoint.x;
    //          frameClickMap.Y = this.ClickPoint.y;
    //          frameClickMap.Z = this.ClickPoint.z;
    //          ETModel.SessionComponent.Instance.Session.Send(frameClickMap);

                //	// 测试actor rpc消息
                //	this.TestActor().Coroutine();
                //}
                //}
        }

	    public async ETVoid TestActor()
	    {
		    try
		    {
			    M2C_ShipSkillResponse response = (M2C_ShipSkillResponse)await SessionComponent.Instance.Session.Call(
						new C2M_ShipSkillRequest() { Info = "actor rpc request" });
			    Log.Info(response.Info);
			}
		    catch (Exception e)
		    {
				Log.Error(e);
		    }
		}
    }
}
