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
    /// 합 스킬 리스트
    /// </summary>
    public List<ClashPoint> clashSkillList;

    /// <summary>
    /// 배틀하는 플레이어 유닛
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
    /// 사무소에서 전투가능한 유닛베이스 받아오기
    /// </summary>
    void GetUnitBase()
    {
        for (int i = 0; i < 6; i++)
        {
            battlePlayerUnit[i] = PlayerOffiece.Instance.officeBattleUnits[i];
        }
    }

    /// <summary>
    /// 주사위 1개 단위의 충돌 처리
    /// </summary>
    void HandleClashDice(int index, Skill playerSkill, Skill enemySkill, UnitBase playerUnit, UnitBase enemyUnit)
    {
        int playerValue = RollDiceSafe(playerSkill, index, playerUnit);
        int enemyValue = RollDiceSafe(enemySkill, index, enemyUnit);

        // 일방공격 처리 넣을예정

        ApplyAttackLevelBonus(ref playerValue, ref enemyValue, playerUnit.attackLevel, enemyUnit.attackLevel);

        // 위력 증가, 효과 적용 등 넣을예정

        // 주사위값으로 합 진행
    }

    /// <summary>
    /// 주사위 굴림 (없는 인덱스면 0 반환)
    /// </summary>
    int RollDiceSafe(Skill skill, int index, UnitBase unit)
    {
        if (index < skill.skillDice.Length)
            return skill.rollDice(index, unit);
        return 0; // 없는 주사위는 0으로 처리
    }

    /// <summary>
    /// 공격 레벨 보정 적용
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
