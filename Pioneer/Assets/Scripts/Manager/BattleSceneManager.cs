using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{
    /// <summary>
    /// �÷��̾� ���� �⺻ ��ġ
    /// </summary>
    public Transform[] playerUnitBaseTrans = new Transform[6];

    /// <summary>
    /// �� ���� �⺻ ��ġ
    /// </summary>
    public Transform[] enemyUnitBaseTrans = new Transform[6];

    /// <summary>
    /// ���ֺ� �÷��̾� ��ũ��Ʈ �迭
    /// </summary>
    public UnitView[] playerUnitView = new UnitView[6];

    /// <summary>
    /// ���ֺ� �� ��ũ��Ʈ �迭
    /// </summary>
    public UnitView[] enemyUnitView = new UnitView[6];

    /// <summary>
    /// ���� �� ������Ʈ
    /// </summary>
    public GameObject unitViewObj = null;

    /// <summary>
    /// ��Ʋ�Ŵ��� �ν��Ͻ�
    /// </summary>
    [SerializeField] BattleManager BattleManager = null;

    /// <summary>
    /// ��Ʋ�Ŵ����� ���� ���� ���ֿ��� ���� �̾ƿ���
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
