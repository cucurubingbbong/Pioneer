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

    void Clash()
    {

    }


}
