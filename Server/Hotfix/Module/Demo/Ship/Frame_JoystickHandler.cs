using ETModel;
using PF;
using UnityEngine;

namespace ETHotfix
{
	[ActorMessageHandler(AppType.Map)]
	public class Frame_JoystickHandler : AMActorLocationHandler<Ship, Frame_Joystick>
	{
		protected override void Run(Ship ship, Frame_Joystick message)
		{
			Vector3 target = new Vector3(message.X, message.Y, message.Z);
            ship.GetComponent<ShipSkillComponent>().MoveTo(target).Coroutine();
			
		}
	}
}