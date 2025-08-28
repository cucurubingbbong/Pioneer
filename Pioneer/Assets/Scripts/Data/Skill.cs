using UnityEngine;

[CreateAssetMenu(menuName = "Skill/CasterSkill")]
public class Skill : ScriptableObject
{
    /// <summary>
    /// 스킬이름
    /// </summary>
    public string skillName;

    /// <summary>
    /// 스킬의 구성 주사위
    /// </summary>
    public Dice[] skillDice;

}

