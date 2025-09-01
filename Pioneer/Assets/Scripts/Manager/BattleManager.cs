using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [System.Serializable]
    public class ClashPoint
    {
        public UnitBase playerUnit;
        public UnitBase enemyUnit;
        public Skill PlayerSkill;
        public Skill EnemySkill;
    }

    /// <summary>
    /// �� ��ų ����Ʈ
    /// </summary>
    public List<ClashPoint> clashSkillList;

    /// <summary>
    /// ��Ʋ�ϴ� �÷��̾� ����
    /// </summary>
    public UnitBase[] battlePlayerUnit = new UnitBase[6];

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
    /// �繫�ҿ��� ���������� ���ֺ��̽� �޾ƿ���
    /// </summary>
    void GetUnitBase()
    {
        for (int i = 0; i < 6; i++)
        {
            battlePlayerUnit[i] = PlayerOffiece.Instance.officeBattleUnits[i];
        }
    }

    /// <summary>
    /// �ֻ��� 1�� ������ �浹 ó��
    /// </summary>
    void HandleClashDice(int index, Skill playerSkill, Skill enemySkill, UnitBase playerUnit, UnitBase enemyUnit)
    {
        int playerValue = RollDiceSafe(playerSkill, index, playerUnit);
        int enemyValue = RollDiceSafe(enemySkill, index, enemyUnit);

        // �Ϲ���� ó�� ��������

        ApplyAttackLevelBonus(ref playerValue, ref enemyValue, playerUnit.attackLevel, enemyUnit.attackLevel);

        // ���� ����, ȿ�� ���� �� ��������

        // �ֻ��������� �� ����
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
