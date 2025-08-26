using UnityEngine;

[SerializeField] 

public class DIce
{
    public int minValue = 0;
    public int maxValue = 0; 
    KeyWord diceKeyWord = KeyWord.None;
}
abstract class Skill
{
    /// <summary>
    /// 스킬의 주사위 
    /// </summary>
    public DIce[] skillDice = new DIce[0];

    public DIce currentDice = null;

    /// <summary>
    /// 스킬 타입
    /// </summary>
    public SkillType skillType = SkillType.Casting;

    /// <summary>
    /// 시전자
    /// </summary>
    UnitBase caster = null;

    /// <summary>
    /// 타겟
    /// </summary>
    UnitBase target = null;

    public abstract void TurnStart(UnitBase target);

    public abstract void ApplyDice(DIce dice, UnitBase caster, UnitBase target);

}
