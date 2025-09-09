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

    /// <summary>
    /// ��Ʋ �� �Ŵ���
    /// </summary>

    public BattleSceneManager battleSceneManager = null;

    private void Start()
    {
        BattleSetting();
    }

    /// <summary>
    /// ��Ʋ ����
    /// </summary>
    public void BattleSetting()
    {
        GetUnitBase();
        battleSceneManager.UnitViewSetting();
    }

    /// <summary>
    /// ���� ����
    /// </summary>
    public void BattleStart()
    {
        Clash();
    }

    /// <summary>
    /// �繫�ҿ��� ���������� ���ֺ��̽� �޾ƿ���
    /// </summary>
    void GetUnitBase()
    {
        for (int i = 0; i < 6; i++)
        {
            if (PlayerOffiece.Instance.officeBattleUnits[i] == null) continue;
            battlePlayerUnit[i] = PlayerOffiece.Instance.officeBattleUnits[i];
        }
    }


    /// <summary>
    /// ��
    /// </summary>
    
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
        // 1. �ֻ��� �� ����
        int playerValue = RollDiceSafe(playerSkill, index, playerUnit);
        int enemyValue = RollDiceSafe(enemySkill, index, enemyUnit);

        // 2. �Ϲ� ���� (��� �ֻ��� ���ٸ� �׳� ���� ����)
        if (enemySkill == null || index >= enemySkill.skillDice.Length)
        {
            playerSkill.skillDice[index].Apply(playerUnit, enemyUnit, playerValue);
            return;
        }

        // 3. ���� (����, ����/����� ��)
        ApplyAttackLevelBonus(ref playerValue, ref enemyValue, playerUnit.attackLevel, enemyUnit.attackLevel);

        // 4. ��
        if (playerValue > enemyValue)
        {
            playerSkill.skillDice[index].Apply(playerUnit, enemyUnit, playerValue);
            enemySkill.skillDice[index].Break(); // �� �ֻ����� �ı�
        }
        else if (playerValue < enemyValue)
        {
            enemySkill.skillDice[index].Apply(enemyUnit, playerUnit, enemyValue);
            playerSkill.skillDice[index].Break(); // �� �ֻ����� �ı�
        }
        else
        {
            // 5. ���º�  �� �� �ı�
            playerSkill.skillDice[index].Break();
            enemySkill.skillDice[index].Break();

            Debug.Log($"���º� �߻�! {playerUnit.unitName}�� {enemyUnit.unitName}�� �ֻ���({playerValue})�� �ı��Ǿ����ϴ�.");
        }
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
