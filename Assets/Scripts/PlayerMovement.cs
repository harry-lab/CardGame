using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public JoystickInput joystick;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // 입력 처리
        Vector2 input = joystick.InputDirection;
        moveInput = input.normalized;
    }

    private void FixedUpdate()
    {
        // Rigidbody2D로 이동 처리
        rb.linearVelocity = moveInput * moveSpeed;

        //  바라보는 방향 회전 (선택사항)
        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
        }
    }
}