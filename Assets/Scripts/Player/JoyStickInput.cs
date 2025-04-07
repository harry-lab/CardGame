using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickInput : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [Header("UI References")]
    public RectTransform background;
    public RectTransform handle;

    private Vector2 inputDirection = Vector2.zero;
    public Vector2 InputDirection => inputDirection;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background, eventData.position, eventData.pressEventCamera, out pos);

        float radius = background.sizeDelta.x * 0.5f;
        pos = Vector2.ClampMagnitude(pos, radius);
        handle.anchoredPosition = pos;
        inputDirection = pos / radius;
    }

    public void OnPointerDown(PointerEventData eventData) => OnDrag(eventData);

    public void OnPointerUp(PointerEventData eventData)
    {
        inputDirection = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
}