using UnityEngine;

namespace RotationControls
{
    public sealed class KinematicRotationControls : RotationControls
    {
        private readonly Transform _target;
        private readonly float _anglesPerScreen;

        public KinematicRotationControls(Transform target, Camera camera, float anglesPerScreen, bool invert) : base(camera)
        {
            _target = target;
            _anglesPerScreen = anglesPerScreen * (invert ? -1f : 1f);
        }
    
        public override void Rotate(Vector2 pointerDelta)
        {
            var axis = GetAxis(pointerDelta);
            var angle = GetAngle(pointerDelta);

            _target.Rotate(axis, angle, Space.World);
        }

        private float GetAngle(Vector2 delta)
        {
            var viewportDelta = Camera.ScreenToViewportPoint(delta);
            var viewportDistance = viewportDelta.magnitude;
            var angle = viewportDistance * _anglesPerScreen;

            return angle;
        }
    }
}