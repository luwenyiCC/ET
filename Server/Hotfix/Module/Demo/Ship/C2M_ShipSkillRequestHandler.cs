using System;
using ETModel;

namespace ETHotfix
{
	[ActorMessageHandler(AppType.Map)]
	public class C2M_ShipSkillRequestHandler : AMActorLocationRpcHandler<Ship, C2M_ShipSkillRequest, M2C_ShipSkillResponse>
	{
		protected override async ETTask Run(Ship unit, C2M_ShipSkillRequest message, Action<M2C_ShipSkillResponse> reply)
		{
            //NOTE 移动的最后发送这个消息  还不知道为什么
			reply(new M2C_ShipSkillResponse(){Info = "actor rpc response"});
			await ETTask.CompletedTask;
		}
	}
}