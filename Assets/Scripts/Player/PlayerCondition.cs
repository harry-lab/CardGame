using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public int currentHp { get; private set; }  // �ܺο��� �б⸸ ����

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

        Debug.Log($" �÷��̾� ������: {finalDamage} | ���� ü��: {currentHp}");

        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHp = Mathf.Min(currentHp + amount, stats.maxHp);
        Debug.Log($" ȸ��: {amount} | ���� ü��: {currentHp}");
    }

    private void Die()
    {
        Debug.Log(" �÷��̾� ���");
        // ���� ���� UI ����, �� ��ȯ �� ó�� ����
    }
}
