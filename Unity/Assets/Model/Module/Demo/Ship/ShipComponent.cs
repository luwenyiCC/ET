using System.Collections.Generic;
using System.Linq;

namespace ETModel
{
	[ObjectSystem]
	public class ShipComponentSystem : AwakeSystem<ShipComponent>
	{
		public override void Awake(ShipComponent self)
		{
			self.Awake();
		}
	}
	
	public class ShipComponent: Component
	{
		public static ShipComponent Instance { get; private set; }

		public Ship MyShip;
		
		private readonly Dictionary<long, Ship> idShips = new Dictionary<long, Ship>();

		public void Awake()
		{
			Instance = this;
		}

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}
			base.Dispose();

			foreach (Ship ship in this.idShips.Values)
			{
				ship.Dispose();
			}

			this.idShips.Clear();

			Instance = null;
		}

		public void Add(Ship ship)
		{
			this.idShips.Add(ship.Id, ship);
			ship.Parent = this;
		}

		public Ship Get(long id)
		{
			Ship ship;
			this.idShips.TryGetValue(id, out ship);
			return ship;
		}

		public void Remove(long id)
		{
			Ship ship;
			this.idShips.TryGetValue(id, out ship);
			this.idShips.Remove(id);
			ship?.Dispose();
		}

		public void RemoveNoDispose(long id)
		{
			this.idShips.Remove(id);
		}

		public int Count
		{
			get
			{
				return this.idShips.Count;
			}
		}

		public Ship[] GetAll()
		{
			return this.idShips.Values.ToArray();
		}
	}
}