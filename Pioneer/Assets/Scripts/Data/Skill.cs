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
    /// ��ų�� �ֻ��� 
    /// </summary>
    public DIce[] skillDice = new DIce[0];

    public DIce currentDice = null;

    /// <summary>
    /// ��ų Ÿ��
    /// </summary>
    public SkillType skillType = SkillType.Casting;

    /// <summary>
    /// ������
    /// </summary>
    UnitBase caster = null;

    /// <summary>
    /// Ÿ��
    /// </summary>
    UnitBase target = null;

    public abstract void TurnStart(UnitBase target);

    public abstract void ApplyDice(DIce dice, UnitBase caster, UnitBase target);

}
