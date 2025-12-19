using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerController : MonoBehaviour
{

    [Header(" Elements ")]
    [SerializeField] private MobileJoystick joystick;
    private PlayerAnimator playerAnimator;
    private CharacterController characterController;

    [Header(" Settings ")]
    [SerializeField] private float moveSpeed = 5f;

    // Start is called once before the first execution of Update after th
    // e MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageMovement();
    }
    private void ManageMovement()
    {

        Vector3 moveVector = joystick.GetMoveVector() * moveSpeed * Time.deltaTime / Screen.width;
        moveVector.z = moveVector.y;
        moveVector.y = 0;
        characterController.Move(moveVector);
        playerAnimator.ManageAnimations(moveVector);
    }
}
