using UnityEngine;

namespace RotationControls
{
    public sealed class DynamicRotationControls : RotationControls
    {
        private readonly Rigidbody _target;
        private readonly float _speedPerScreen;

        public DynamicRotationControls(Rigidbody target, Camera camera, float speedPerScreen, bool invert) : base(camera)
        {
            _target = target;
            _speedPerScreen = speedPerScreen * (invert ? -1f : 1f);
        }
    
        public override void Rotate(Vector2 pointerDelta)
        {
            var axis = GetAxis(pointerDelta);
            var speed = GetSpeed(pointerDelta);
            var torque = axis * speed;
        
            _target.AddTorque(torque, ForceMode.VelocityChange);
        }

        private float GetSpeed(Vector2 delta)
        {
            var viewportDelta = Camera.ScreenToViewportPoint(delta);
            var viewportDistance = viewportDelta.magnitude;
            var speed = viewportDistance * _speedPerScreen;

            return speed;
        }
    }
}