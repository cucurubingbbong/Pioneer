using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{
    /// <summary>
    /// 플레이어 유닛 기본 위치
    /// </summary>
    public Transform[] playerUnitBaseTrans = new Transform[6];

    /// <summary>
    /// 적 유닛 기본 위치
    /// </summary>
    public Transform[] enemyUnitBaseTrans = new Transform[6];

    public void SetTransForm(UnitBase[] playerUnitBase , UnitBase[] enemyUnitBase)
    {
        // 편성 순서대로 세팅
        for (int i = 0; i < playerUnitBase.Length; i++)
        {
            playerUnitBase[0].transform.position = playerUnitBase[i].transform.position;
        }
    }
}
