using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public int currentHp { get; private set; }  // 외부에선 읽기만 가능

    private PlayerStats stats;

    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
        currentHp = stats.maxHp;
    }

    public void TakeDamage(int incomingDamage)
    {
        int finalDamage = stats.GetDamageAfterDefense(incomingDamage);
        currentHp -= finalDamage;

        Debug.Log($" 플레이어 데미지: {finalDamage} | 남은 체력: {currentHp}");

        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHp = Mathf.Min(currentHp + amount, stats.maxHp);
        Debug.Log($" 회복: {amount} | 현재 체력: {currentHp}");
    }

    private void Die()
    {
        Debug.Log(" 플레이어 사망");
        // 게임 오버 UI 띄우기, 씬 전환 등 처리 가능
    }
}
