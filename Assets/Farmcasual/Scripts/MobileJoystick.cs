using UnityEngine;
using UnityEngine.InputSystem;

public class MobileJoystick : MonoBehaviour
{

    [Header(" Elements ")]
    [SerializeField] private RectTransform joystickOutline;
    [SerializeField] private RectTransform joystickKnob;

    [Header(" Settings ")]
    [SerializeField] private bool canControl;
    [SerializeField] private float moveFactor = 540f;
    private Vector3 move;
    private Vector3 clickedPosition;


    void Start()
    {
        HideJoystick();
    }

    void Update()
    {
        if (canControl)
        {
            ControlJoystick();
        }
    }

    public void ClickedOnJoystickZoneCallback()
    {
        clickedPosition = Pointer.current.position.ReadValue();
        joystickOutline.position = clickedPosition;
        ShowJoystick();
    }

    private void ShowJoystick()
    {
        joystickOutline.gameObject.SetActive(true);
        canControl = true;
    }

    private void HideJoystick()
    {
        joystickOutline.gameObject.SetActive(false);
        canControl = false;
        move = Vector3.zero;
    }

    private void ControlJoystick()
    {
        Vector3 currentPosition = Pointer.current.position.ReadValue();
        Vector3 direction = currentPosition - clickedPosition;

        float moveMagnitude = direction.magnitude * moveFactor / Screen.width;

        moveMagnitude = Mathf.Min(moveMagnitude, joystickOutline.rect.width / 2);

        move = direction.normalized * moveMagnitude;
        Vector3 targetPosition = clickedPosition + move;
        joystickKnob.position = targetPosition;

        if (!Pointer.current.press.isPressed)
        {
            HideJoystick();
        }
    }

    public Vector3 GetMoveVector()
    {
        return move;
    }
}
