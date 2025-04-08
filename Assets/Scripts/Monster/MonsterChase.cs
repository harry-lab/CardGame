using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MonsterChase : MonoBehaviour
{
    public float chaseRange = 5f;
    public float moveSpeed = 2f;

    private Transform player;
    private Rigidbody2D rb;

    private bool hasDetectedPlayer = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        if (!hasDetectedPlayer)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance < chaseRange)
            {
                hasDetectedPlayer = true;
            }
        }

        if (hasDetectedPlayer)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            rb.linearVelocity = dir * moveSpeed;

            // 🔧 캐릭터 방향 전환 처리 (왼쪽/오른쪽)
            if (dir.x != 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Sign(dir.x) * Mathf.Abs(scale.x); // 방향에 따라 뒤집음
                transform.localScale = scale;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var pc = collision.gameObject.GetComponent<PlayerCondition>();
            if (pc != null)
            {
                pc.TakeDamage(10);
            }
        }
    }
}