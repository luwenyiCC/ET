using PF;
using UnityEngine;

namespace ETModel
{
	public enum ShipType
	{
        Shuttle,//穿梭机（
        Frigate,//护卫舰
        cruiser//巡洋舰

    }

	[ObjectSystem]
	public class ShipAwakeSystem : AwakeSystem<Ship, ShipType>
	{
		public override void Awake(Ship self, ShipType a)
		{
			self.Awake(a);
		}
	}

	public sealed class Ship: Entity
	{
		public ShipType ShipType { get; private set; }
		
		public Vector3 Position { get; set; }
		
		public void Awake(ShipType unitType)
		{
			this.ShipType = unitType;
		}

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			base.Dispose();
		}
	}
}