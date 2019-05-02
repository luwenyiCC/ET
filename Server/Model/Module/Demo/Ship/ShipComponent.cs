using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ETModel
{
	public class ShipComponent : Component
	{
		[BsonElement]
		[BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
		private readonly Dictionary<long, Ship> idShips = new Dictionary<long, Ship>();

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
		}

		public void Add(Ship ship)
		{
			this.idShips.Add(ship.Id, ship);
		}

		public Ship Get(long id)
		{
			this.idShips.TryGetValue(id, out Ship ship);
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