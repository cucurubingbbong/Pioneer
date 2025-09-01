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

    public void SetTransForm(UnitBase[] playerUnitBase , UnitBase[] enemyUnitBase)
    {
        // �� ������� ����
        for (int i = 0; i < playerUnitBase.Length; i++)
        {
            playerUnitBase[0].transform.position = playerUnitBase[i].transform.position;
        }
    }
}
