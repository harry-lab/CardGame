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
        // ���� ī�� ���� �� ���� ���� ����
        movement.enabled = true;
    }
}