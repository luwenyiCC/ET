using ETModel;

namespace ETHotfix
{
	public static class MessageHelper
	{
		public static void Broadcast(IActorMessage message)
		{
            //广播事件
            Ship[] ships = Game.Scene.GetComponent<ShipComponent>().GetAll();
            ActorMessageSenderComponent actorLocationSenderComponent = Game.Scene.GetComponent<ActorMessageSenderComponent>();
            foreach (Ship ship in ships)
            {
                ShipGateComponent shipGateComponent = ship.GetComponent<ShipGateComponent>();
                if (shipGateComponent.IsDisconnect)
                {
                    continue;
                }

                ActorMessageSender actorMessageSender = actorLocationSenderComponent.Get(shipGateComponent.GateSessionActorId);
                actorMessageSender.Send(message);
            }

            //Unit[] units = Game.Scene.GetComponent<UnitComponent>().GetAll();
            //ActorMessageSenderComponent actorLocationSenderComponent = Game.Scene.GetComponent<ActorMessageSenderComponent>();
            //foreach (Unit unit in units)
            //{
            //	UnitGateComponent unitGateComponent = unit.GetComponent<UnitGateComponent>();
            //	if (unitGateComponent.IsDisconnect)
            //	{
            //		continue;
            //	}

            //	ActorMessageSender actorMessageSender = actorLocationSenderComponent.Get(unitGateComponent.GateSessionActorId);
            //	actorMessageSender.Send(message);
            //}
        }
	}
}
