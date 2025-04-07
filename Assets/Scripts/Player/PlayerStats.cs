using UnityEngine;

[System.Serializable]
public class PlayerStats : MonoBehaviour
{
    [Header("기본 스탯")]
    public int maxHp = 100;
    public int attack = 10;
    public int defense = 5;

    public int GetDamageAfterDefense(int incomingDamage)
    {
        int reduced = incomingDamage - defense;
        return Mathf.Max(1, reduced); // 방어력이 높아도 최소 1 데미지는 입음
    }
}