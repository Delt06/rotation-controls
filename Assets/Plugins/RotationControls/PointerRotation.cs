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
            return new KinematicRotationControls(_target, _camera, _sensitivity, _invert);
        }

        private RotationControls _controls;
    }
}