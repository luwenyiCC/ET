using System;
using ETModel;
using PF;
using UnityEngine;

namespace ETHotfix
{
	[MessageHandler(AppType.Map)]
	public class G2M_CreateShipHandler : AMRpcHandler<G2M_CreateShip, M2G_CreateShip>
	{
		protected override void Run(Session session, G2M_CreateShip message, Action<M2G_CreateShip> reply)
		{
			RunAsync(session, message, reply).Coroutine();
		}
		
		protected async ETVoid RunAsync(Session session, G2M_CreateShip message, Action<M2G_CreateShip> reply)
		{
            //NOTE 第二时间 游戏服务器收到创建Unit的请求
            M2G_CreateShip response = new M2G_CreateShip();
			try
			{
                Ship ship = ComponentFactory.CreateWithId<Ship>(IdGenerater.GenerateId());
                ship.AddComponent<MoveComponent>();
                ship.AddComponent<ShipSkillComponent>();
                ship.Position = new Vector3(-10, 0, -10);
				
				await ship.AddComponent<MailBoxComponent>().AddLocation();
                ship.AddComponent<ShipGateComponent, long>(message.GateSessionId);
				Game.Scene.GetComponent<ShipComponent>().Add(ship);
				response.ShipId = ship.Id;


                // 广播创建的unit
                M2C_CreateShips createShips = new M2C_CreateShips();
                Ship[] ships = Game.Scene.GetComponent<ShipComponent>().GetAll();
				foreach (Ship itemShip in ships)
				{
                    ShipInfo shipInfo = new ShipInfo();
					shipInfo.X = itemShip.Position.x;
					shipInfo.Y = itemShip.Position.y;
					shipInfo.Z = itemShip.Position.z;
					shipInfo.ShipId = itemShip.Id;
                    createShips.Ships.Add(shipInfo);
				}
				MessageHelper.Broadcast(createShips);
				
				
				reply(response);
			}
			catch (Exception e)
			{
				ReplyError(response, e, reply);
			}
		}
	}
}