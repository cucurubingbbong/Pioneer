using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ClashManager : MonoBehaviour
{
    [System.Serializable]
    public class ClashPoint
    {
        public Skill PlayerSkill;
        public Skill EnemySkill;
    }

    public List<ClashPoint> clashSkillList;

    public void BattleStart()
    {

    }

    /// <summary>
    /// гу
    /// </summary>
    void Clash()
    {
        for (int i = 0; i < clashSkillList.Count; i++)
        {
            Skill playerSkill = clashSkillList[i].PlayerSkill;
            Skill enemySkill = clashSkillList[i].EnemySkill;

            //int clashDiceCount = (playerSkill.skillDice.Length == enemySkill.skillDice.Length) ? playerSkill.skillDice.Length : (playerSkill.skillDice.Length > enemySkill.skillDice.Length) ? playerSkill.skillDice.Length : enemySkill.skillDice.Length;
            int clashDiceCount = Mathf.Max(playerSkill.skillDice.Length, enemySkill.skillDice.Length);



        }
    }


}
