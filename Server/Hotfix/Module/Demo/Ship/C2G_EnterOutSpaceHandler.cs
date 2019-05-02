using System;
using System.Net;
using ETModel;

namespace ETHotfix
{
	[MessageHandler(AppType.Gate)]
	public class C2G_EnterOutSpaceHandler : AMRpcHandler<C2G_EnterOutSpace, G2C_EnterOutSpace>
	{
		protected override void Run(Session session, C2G_EnterOutSpace message, Action<G2C_EnterOutSpace> reply)
		{
			RunAsync(session, message, reply).Coroutine();
		}
		
		protected async ETVoid RunAsync(Session session, C2G_EnterOutSpace message, Action<G2C_EnterOutSpace> reply)
		{
            G2C_EnterOutSpace response = new G2C_EnterOutSpace();
			try
			{//NOTE 进入地图后第一个调用
				Player player = session.GetComponent<SessionPlayerComponent>().Player;
				// 在map服务器上创建战斗Unit
				IPEndPoint mapAddress = StartConfigComponent.Instance.MapConfigs[0].GetComponent<InnerConfig>().IPEndPoint;//取得战斗服地址
				Session mapSession = Game.Scene.GetComponent<NetInnerComponent>().Get(mapAddress);
                M2G_CreateShip createUnit = (M2G_CreateShip)await mapSession.Call(new G2M_CreateShip() { PlayerId = player.Id, GateSessionId = session.InstanceId });//向战斗服创建unit
				player.ShipId = createUnit.ShipId;
				response.ShipId = createUnit.ShipId;
				reply(response);
			}
			catch (Exception e)
			{
				ReplyError(response, e, reply);
			}
		}
	}
}