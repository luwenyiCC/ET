using UnityEngine;

namespace ETModel
{
	[ObjectSystem]
	public class CameraComponentAwakeSystem : AwakeSystem<CameraComponent>
	{
		public override void Awake(CameraComponent self)
		{
			self.Awake();
		}
	}

	[ObjectSystem]
	public class CameraComponentLateUpdateSystem : LateUpdateSystem<CameraComponent>
	{
		public override void LateUpdate(CameraComponent self)
		{
			self.LateUpdate();
		}
	}

	public class CameraComponent : Component
	{
		// 战斗摄像机
		public Camera mainCamera;

        public Ship ship;
        //public Unit Unit;

		public Camera MainCamera
		{
			get
			{
				return this.mainCamera;
			}
		}

		public void Awake()
		{
			this.mainCamera = Camera.main;
		}

		public void LateUpdate()
		{
			// 摄像机每帧更新位置
			UpdatePosition();
		}

		private void UpdatePosition()
		{
			Vector3 cameraPos = this.mainCamera.transform.position;
			this.mainCamera.transform.position = new Vector3(this.ship.Position.x, cameraPos.y, this.ship.Position.z - 1);
		}
	}
}
