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

    public int rollDice(int diceNumber, UnitBase caster)
    {
        int min = skillDice[diceNumber].minValue;
        int max = skillDice[diceNumber].maxValue;

        // 정신력 비율 (-50 ~ 50)
        float mentalRatio = Mathf.Clamp(caster.mentalPower / 50f, -1f, 1f);

        float normalized = (mentalRatio + 1f) / 2f;

        // 중심값 계산
        float center = min + (max - min) * normalized;

        float rand1 = Random.Range(min, max + 1);
        float rand2 = Random.Range(min, max + 1);
        int value = Mathf.RoundToInt((rand1 + rand2 + center) / 3f);

        value = Mathf.Clamp(value, min, max);

        return value;
    }
}

