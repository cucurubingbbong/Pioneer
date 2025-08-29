using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ClashManager : MonoBehaviour
{
    [System.Serializable]
    public class ClashPoint
    {
        public UnitBase playerUnit;
        public UnitBase enemyUnit;
        public Skill PlayerSkill;
        public Skill EnemySkill;
    }

    public List<ClashPoint> clashSkillList;

    private void Start()
    {
        Clash();
    }
    void Clash()
    {
        foreach (var clash in clashSkillList)
        {
            Skill playerSkill = clash.PlayerSkill;
            Skill enemySkill = clash.EnemySkill;
            UnitBase playerUnit = clash.playerUnit;
            UnitBase enemyUnit = clash.enemyUnit;

            int clashDiceCount = Mathf.Max(playerSkill.skillDice.Length, enemySkill.skillDice.Length);

            for (int j = 0; j < clashDiceCount; j++)
            {
                HandleClashDice(j, playerSkill, enemySkill, playerUnit, enemyUnit);
            }
        }
    }

    /// <summary>
    /// �ֻ��� 1�� ������ �浹 ó��
    /// </summary>
    void HandleClashDice(int index, Skill playerSkill, Skill enemySkill, UnitBase playerUnit, UnitBase enemyUnit)
    {
        int playerValue = RollDiceSafe(playerSkill, index, playerUnit);
        int enemyValue = RollDiceSafe(enemySkill, index, enemyUnit);

        ApplyAttackLevelBonus(ref playerValue, ref enemyValue, playerUnit.attackLevel, enemyUnit.attackLevel);

        // ���� ����, ȿ�� ���� �� ��������
        Debug.Log($"Dice {index}: Player({playerValue}) vs Enemy({enemyValue})");
    }

    /// <summary>
    /// �ֻ��� ���� (���� �ε����� 0 ��ȯ)
    /// </summary>
    int RollDiceSafe(Skill skill, int index, UnitBase unit)
    {
        if (index < skill.skillDice.Length)
            return skill.rollDice(index, unit);
        return 0; // ���� �ֻ����� 0���� ó��
    }

    /// <summary>
    /// ���� ���� ���� ����
    /// </summary>
    void ApplyAttackLevelBonus(ref int playerValue, ref int enemyValue, int playerAtkLevel, int enemyAtkLevel)
    {
        int diff = Mathf.Abs(playerAtkLevel - enemyAtkLevel);

        if (playerAtkLevel > enemyAtkLevel)
            playerValue += diff / 3;
        else if (enemyAtkLevel > playerAtkLevel)
            enemyValue += diff / 3;
    }



}
