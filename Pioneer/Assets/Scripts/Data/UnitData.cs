using UnityEngine;

[CreateAssetMenu(menuName = "Unit/UnitData")]
public class UnitData : ScriptableObject
{
    public string unitName;
    public float baseMaxHp;
    public int baseAttackLevel;
    public int baseDefenseLevel;
    public int baseSpeed;
    public int baseMentalPower;
    public Skill[] baseSkill = null;
}
