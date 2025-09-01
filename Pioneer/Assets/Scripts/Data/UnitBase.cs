using UnityEngine;

[System.Serializable]
public class UnitBase : MonoBehaviour
{
    public string unitName;
    public float maxHp;
    public float currentHp;
    public int attackLevel;
    public int defenseLevel;
    public int speed;
    public int mentalPower;
    public int level = 1;
    public Skill[] skillList = null;

    // �ʱ�ȭ
    public UnitBase(UnitData data)
    {
        unitName = data.unitName;
        maxHp = data.baseMaxHp;
        currentHp = maxHp;
        attackLevel = data.baseAttackLevel;
        defenseLevel = data.baseDefenseLevel;
        speed = data.baseSpeed;
        mentalPower = data.baseMentalPower;
        skillList = new Skill[data.baseSkill.Length];
        for (int i = 0; i < data.baseSkill.Length; i++)
        {
            skillList[i] = data.baseSkill[i]; 
        }
    }

    // ���� �� ���� �ݿ�
    public void LevelUp()
    {
        // ����
    }

    // GameManager ����� ����
    public UnitBase Clone()
    {
        return (UnitBase)this.MemberwiseClone();
    }
}
