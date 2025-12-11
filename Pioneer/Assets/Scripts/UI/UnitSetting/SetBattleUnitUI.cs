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
    }

    void SettingPage(int index)
    {
        for (int i = (index * 10) - 10; i < index;)
        {
            GameObject obj = Instantiate(battleUnitUi, placeUiTrans);
            SettingUnitView bi = obj.GetComponent<SettingUnitView>();

            bi.Setting(OfficeManager.Instance.officeUnit[i]);
        }
    }
}
