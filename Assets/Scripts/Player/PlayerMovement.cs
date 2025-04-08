using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public JoystickInput joystick;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 조이스틱 입력 처리
        Vector2 input = joystick.InputDirection;
        moveInput = input.normalized;

        // 애니메이션 Speed 설정
        animator.SetFloat("Speed", moveInput.magnitude);

        //  좌우 반전 처리
        if (moveInput.x > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1); // 오른쪽
        }
        else if (moveInput.x < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1); // 왼쪽
        }
    }

    private void FixedUpdate()
    {
        // 물리 이동 처리
        rb.linearVelocity = moveInput * moveSpeed;
    }
}