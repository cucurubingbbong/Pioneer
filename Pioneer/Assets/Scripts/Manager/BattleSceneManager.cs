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
    /// ��Ʋ�Ŵ������� ���� ���� ���ֿ��� ���� �̾ƿ���
    /// </summary>
    public void UnitViewSetting()
    {
        for (int i = 0; i < BattleManager.battlePlayerUnit.Length; i++)
        {
            GameObject viewObj = Instantiate(unitViewObj);
            viewObj.transform.SetParent(playerUnitBaseTrans[i].transform, false);
            UnitView view = viewObj.AddComponent<UnitView>();
            playerUnitView[i] = view;
            
        }
    }

}
