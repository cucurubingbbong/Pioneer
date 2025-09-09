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

    /// <summary>
    /// 유닛뷰 플레이어 스크립트 배열
    /// </summary>
    public UnitView[] playerUnitView = new UnitView[6];

    /// <summary>
    /// 유닛뷰 적 스크립트 배열
    /// </summary>
    public UnitView[] enemyUnitView = new UnitView[6];

    /// <summary>
    /// 유닛 뷰 오브젝트
    /// </summary>
    public GameObject unitViewObj = null;

    /// <summary>
    /// 배틀매니저 인스턴스
    /// </summary>
    [SerializeField] BattleManager BattleManager = null;

    /// <summary>
    /// 배틀매니저의 전투 가능 유닛에서 에셋 뽑아오기
    /// </summary>
    public void UnitViewSetting()
    {
        for (int i = 0; i < BattleManager.battlePlayerUnit.Length; i++)
        {
            GameObject viewObj = Instantiate(unitViewObj);
            viewObj.transform.SetParent(playerUnitBaseTrans[i].transform, false);
            UnitView view = viewObj.GetComponent<UnitView>();
            playerUnitView[i] = view;
            SetUnitSpData(view , i );
        }
    }

    public void SetUnitSpData(UnitView unitView, int n)
    {
        if (BattleManager.battlePlayerUnit[n] == null) return;
        if (BattleManager.battlePlayerUnit[n].m_unitSpriteData == null) return;
        if (BattleManager.battlePlayerUnit[n].m_unitSpriteData.unitStandSprite == null) return;

        unitView.unitStandSprite = BattleManager.battlePlayerUnit[n].m_unitSpriteData.unitStandSprite;
        unitView.GetUnitSprite();
    }


}
