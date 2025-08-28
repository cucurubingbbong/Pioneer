using UnityEngine;

[CreateAssetMenu(menuName = "Skill/CasterSkill")]
public class Skill : ScriptableObject
{
    /// <summary>
    /// ��ų�̸�
    /// </summary>
    public string skillName;

    /// <summary>
    /// ��ų�� ���� �ֻ���
    /// </summary>
    public Dice[] skillDice;

}

