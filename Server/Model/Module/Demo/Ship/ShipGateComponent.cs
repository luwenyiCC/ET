namespace ETModel
{
	[ObjectSystem]
	public class ShipGateComponentAwakeSystem : AwakeSystem<ShipGateComponent, long>
	{
		public override void Awake(ShipGateComponent self, long a)
		{
			self.Awake(a);
		}
	}

	public class ShipGateComponent : Component, ISerializeToEntity
	{
		public long GateSessionActorId;

		public bool IsDisconnect;

		public void Awake(long gateSessionId)
		{
			this.GateSessionActorId = gateSessionId;
		}
	}
}