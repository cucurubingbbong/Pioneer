using UnityEngine;

[System.Serializable]
public class UnitBase 
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
    public UnitSpriteData m_unitSpriteData = null;

    // 초기화
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
        m_unitSpriteData = data.unitSpriteData;
        for (int i = 0; i < data.baseSkill.Length; i++)
        {
            skillList[i] = data.baseSkill[i]; 
        }
    }

    // 전투 후 성장 반영
    public void LevelUp()
    {
        // 성장
    }

    // GameManager 저장용 복사
    public UnitBase Clone()
    {
        return (UnitBase)this.MemberwiseClone();
    }
}
