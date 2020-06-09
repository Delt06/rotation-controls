using UnityEngine;

namespace RotationControls
{
        public abstract class RotationControls
        {
                protected readonly Camera Camera;

                protected RotationControls(Camera camera)
                {
                        Camera = camera;
                }

                protected Vector3 GetAxis(Vector2 delta)
                {
                        return Vector3.Cross(delta, TowardsCamera);
                }

                private Vector3 TowardsCamera => -Camera.transform.forward;
        
                public abstract void Rotate(Vector2 pointerDelta);
        }
}