//Original version can be found at https://github.com/maydinunlu/virtual-joystick-unity

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

        public float Horizontal
        {
            get
            {
                return InputVector.x;
            }
        }

        public float Vertical
        {
            get
            {
                return InputVector.z;
            }
        }

        public void OnPointerDown(PointerEventData e)
        {
            OnDrag(e);
        }

        public void OnDrag(PointerEventData e)
        {
            Vector2 pos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(ImgBg.rectTransform,
                                                                        e.position,
                                                                        e.pressEventCamera,
                                                                        out pos))
            {

                pos.x = (pos.x / ImgBg.rectTransform.sizeDelta.x);
                pos.y = (pos.y / ImgBg.rectTransform.sizeDelta.y);

                InputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
                InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;

                ImgJoystick.rectTransform.anchoredPosition = new Vector3(InputVector.x * (ImgBg.rectTransform.sizeDelta.x * .4f),
                                                                         InputVector.z * (ImgBg.rectTransform.sizeDelta.y * .4f));
            }
        }

        public void OnPointerUp(PointerEventData e)
        {
            InputVector = Vector3.zero;
            ImgJoystick.rectTransform.anchoredPosition = Vector3.zero;
        }
    }
}