using UnityEngine;

namespace RotationControls
{
	public abstract class RotationControls
	{
		protected readonly Camera Camera;

		protected RotationControls(Camera camera) => Camera = camera;

		protected Vector3 GetAxis(Vector2 delta) => Vector3.Cross(DeltaInCameraSpace(delta), TowardsCamera);

		private Vector3 DeltaInCameraSpace(Vector3 delta) => Camera.transform.rotation * delta;

		private Vector3 TowardsCamera => -Camera.transform.forward;

		public abstract void Rotate(Vector2 pointerDelta);
	}
}