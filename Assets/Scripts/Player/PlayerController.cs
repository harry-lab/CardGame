using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement movement;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        // 이후 카드 선택 등 상태 제어 가능
        movement.enabled = true;
    }
}