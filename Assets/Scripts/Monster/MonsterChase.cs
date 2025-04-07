using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MonsterChase : MonoBehaviour
{
    public float chaseRange = 5f;
    public float moveSpeed = 2f;

    private Transform player;
    private Rigidbody2D rb;

    private bool hasDetectedPlayer = false; //  한 번 인식했는지 저장

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player == null) return;

        //  아직 못 봤으면 거리 체크
        if (!hasDetectedPlayer)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance < chaseRange)
            {
                hasDetectedPlayer = true;
            }
        }

        //  한 번 인식했으면 무조건 따라감
        if (hasDetectedPlayer)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            rb.linearVelocity = dir * moveSpeed;
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