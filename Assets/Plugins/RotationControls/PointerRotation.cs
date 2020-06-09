using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RotationControls
{
    public sealed class PointerRotation : MonoBehaviour, IDragHandler
    {
        [SerializeField] private Camera _camera = default;
        [SerializeField] private Rigidbody _target = default;
        [SerializeField] private bool _invert = true;
        [SerializeField] private float _sensitivity = 360f;
        [SerializeField] private Mode _mode = Mode.Kinematic;

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            _controls.Rotate(eventData.delta);
        }

        private void Awake()
        {
            _controls = CreateControls();
        }

        private RotationControls CreateControls()
        {
            switch (_mode)
            {
                case Mode.Kinematic: return new KinematicRotationControls(_target, _camera, _sensitivity, _invert);
                case Mode.Dynamic: return new DynamicRotationControls(_target, _camera, _sensitivity, _invert);
                default: throw new ArgumentOutOfRangeException();
            }
        }

        private RotationControls _controls;
    
        private enum Mode : byte
        {
            Kinematic, Dynamic
        }
    }
}