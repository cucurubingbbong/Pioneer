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

    /// <summary>
    /// 배틀 씬 매니저
    /// </summary>

    public BattleSceneManager battleSceneManager = null;

    private void Start()
    {
        BattleSetting();
    }

    /// <summary>
    /// 배틀 세팅
    /// </summary>
    public void BattleSetting()
    {
        GetUnitBase();
        battleSceneManager.UnitViewSetting();
    }

    /// <summary>
    /// 전투 시작
    /// </summary>
    public void BattleStart()
    {
        Clash();
    }

    /// <summary>
    /// 사무소에서 전투가능한 유닛베이스 받아오기
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
    /// 합
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
    /// 주사위 1개 단위의 충돌 처리
    /// </summary>
    void HandleClashDice(int index, Skill playerSkill, Skill enemySkill, UnitBase playerUnit, UnitBase enemyUnit)
    {
        // 1. 주사위 값 굴림
        int playerValue = RollDiceSafe(playerSkill, index, playerUnit);
        int enemyValue = RollDiceSafe(enemySkill, index, enemyUnit);

        // 2. 일방 공격 (상대 주사위 없다면 그냥 공격 성공)
        if (enemySkill == null || index >= enemySkill.skillDice.Length)
        {
            playerSkill.skillDice[index].Apply(playerUnit, enemyUnit, playerValue);
            return;
        }

        // 3. 보정 (스탯, 버프/디버프 등)
        ApplyAttackLevelBonus(ref playerValue, ref enemyValue, playerUnit.attackLevel, enemyUnit.attackLevel);

        // 4. 비교
        if (playerValue > enemyValue)
        {
            playerSkill.skillDice[index].Apply(playerUnit, enemyUnit, playerValue);
            enemySkill.skillDice[index].Break(); // 진 주사위는 파괴
        }
        else if (playerValue < enemyValue)
        {
            enemySkill.skillDice[index].Apply(enemyUnit, playerUnit, enemyValue);
            playerSkill.skillDice[index].Break(); // 진 주사위는 파괴
        }
        else
        {
            // 5. 무승부  둘 다 파괴
            playerSkill.skillDice[index].Break();
            enemySkill.skillDice[index].Break();

            Debug.Log($"무승부 발생! {playerUnit.unitName}와 {enemyUnit.unitName}의 주사위({playerValue})가 파괴되었습니다.");
        }
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
