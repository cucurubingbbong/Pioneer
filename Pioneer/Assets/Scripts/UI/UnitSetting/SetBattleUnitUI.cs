using UnityEngine;

public class SetBattleUnitUI : MonoBehaviour
{
    [SerializeField] GameObject battleUnitUi = null;

    [SerializeField] Transform placeUiTrans = null;

    /// <summary>
    /// 현재 선택된 편성순서
    /// </summary>
    public int currentIndex = 0;

    private void OnEnable()
    {
        SettingPage(1);
        Debug.Log("전투유닛세팅창");
    }

    void SettingPage(int pageIndex)
    {
        const int pageSize = 10;
        int start = Mathf.Max(0, (pageIndex - 1) * pageSize);
        int end = Mathf.Min(start + pageSize, OfficeManager.Instance.officeUnit.Count);

        for (int i = start; i < end; i++)
        {
            GameObject obj = Instantiate(battleUnitUi, placeUiTrans);
            SettingUnitView bi = obj.GetComponent<SettingUnitView>();
            bi.isBattleUi = false;
            bi.Setting(OfficeManager.Instance.officeUnit[i]);
        }
    }
}
