using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RemoteInput.Core
{
    public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public Image ImgBg;
        public Image ImgJoystick;
        public Vector3 InputVector { get; private set; }

        private Vector2 _drag;
        private float _limit;

        public void Awake()
        {
            _limit = ImgBg.rectTransform.sizeDelta.x * .4f;
        }

        public void OnPointerDown(PointerEventData e)
        {
            _drag = Vector2.zero;
        }

        public void OnDrag(PointerEventData e)
        {
            _drag += e.delta;
            InputVector = new Vector3(_drag.x / _limit, 0, _drag.y / _limit);
            InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;

            var currPos = ImgJoystick.rectTransform.anchoredPosition;
            ImgJoystick.rectTransform.anchoredPosition = new Vector2
                (
                InputVector.x * (ImgBg.rectTransform.sizeDelta.x * .4f),
                InputVector.z * (ImgBg.rectTransform.sizeDelta.y * .4f)
                );
        }

        public void OnPointerUp(PointerEventData e)
        {
            InputVector = Vector3.zero;
            ImgJoystick.rectTransform.anchoredPosition = Vector3.zero;
        }
    }
}