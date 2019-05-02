using UnityEngine;

namespace ETModel
{
    public static class ShipFactory
    {
        public static Ship Create(long id)
        {
            ResourcesComponent resourcesComponent = Game.Scene.GetComponent<ResourcesComponent>();
            GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset("Unit.unity3d", "Unit");
            //GameObject prefab = bundleGameObject.Get<GameObject>("Skeleton");
            GameObject prefab = bundleGameObject.Get<GameObject>("SpaceShip");

            ShipComponent shipComponent = Game.Scene.GetComponent<ShipComponent>();
            
            GameObject go = UnityEngine.Object.Instantiate(prefab);
            Ship ship = ComponentFactory.CreateWithId<Ship, GameObject>(id, go);
            
            //ship.AddComponent<AnimatorComponent>();
            //ship.AddComponent<MoveComponent>();
            //ship.AddComponent<TurnComponent>();
            //ship.AddComponent<UnitPathComponent>();

            shipComponent.Add(ship);
            return ship;
        }
    }
}