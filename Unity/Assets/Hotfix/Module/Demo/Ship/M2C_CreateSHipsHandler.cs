using ETModel;
using PF;
using Vector3 = UnityEngine.Vector3;

namespace ETHotfix
{
	[MessageHandler]
	public class M2C_CreateShipsHandler : AMHandler<M2C_CreateShips>
	{
		protected override void Run(ETModel.Session session, M2C_CreateShips message)
		{
            ShipComponent unitComponent = ETModel.Game.Scene.GetComponent<ShipComponent>();
			
			foreach (ShipInfo unitInfo in message.Ships)
			{
				if (unitComponent.Get(unitInfo.ShipId) != null)
				{
					continue;
				}
				Ship ship = ShipFactory.Create(unitInfo.ShipId);
				ship.Position = new Vector3(unitInfo.X, unitInfo.Y, unitInfo.Z);
			}
		}
	}
}
