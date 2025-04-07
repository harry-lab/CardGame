using UnityEngine;

[System.Serializable]
public class PlayerStats : MonoBehaviour
{
    [Header("�⺻ ����")]
    public int maxHp = 100;
    public int attack = 10;
    public int defense = 5;

    public int GetDamageAfterDefense(int incomingDamage)
    {
        int reduced = incomingDamage - defense;
        return Mathf.Max(1, reduced); // ������ ���Ƶ� �ּ� 1 �������� ����
    }
}