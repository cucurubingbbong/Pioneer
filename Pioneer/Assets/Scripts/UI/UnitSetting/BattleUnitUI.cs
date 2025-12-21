using UnityEngine;


public class BattleUnitUI : MonoBehaviour
{
    /// <summary>
    /// 할당된 전투 유닛 프로필
    /// </summary>

    [SerializeField] SettingUnitView[] assignUnitView = new SettingUnitView[6];

    private void OnEnable()
    {
        BattleUnitSetting();
    }

    private void OnDisable()
    {
        ResetBattleUnitUI();
    }

    /// <summary>
    /// 전투 유닛 Ui 세팅 / OfficeManager.Instance.battleUnit[i] -> 이거 가독성 좋게 수정
    /// </summary>
    void BattleUnitSetting()
    {
        if (OfficeManager.Instance == null || OfficeManager.Instance.battleUnit == null) return;

        int slotCount = Mathf.Min(assignUnitView.Length, OfficeManager.Instance.battleUnit.Length);

        for (int i = 0; i < slotCount; i++)
        {
            if (assignUnitView[i] == null) continue;

            Unit unit = OfficeManager.Instance.battleUnit[i];

            assignUnitView[i].isBattleUi = true; 
            assignUnitView[i].index = i + 1;     // UnitSet에서 사용할 슬롯 번호

            if (unit == null || unit.unitResource == null)
            {
                // 빈 슬롯도 선택창 이동 가능하도록 초기화만 진행
                assignUnitView[i].unitProfile = null;
                assignUnitView[i].assignUnit = null;
            }
            else
            {
                assignUnitView[i].Setting(unit);
            }

            if (assignUnitView[i].selectingLabel != null)
            {
                assignUnitView[i].selectingLabel.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 초기화
    /// </summary>
    void ResetBattleUnitUI()
    {
        for (int i = 0; i < 6; i++)
        {
            SettingUnitView view = assignUnitView[i];
            if (view == null) continue;

            view.isSelecting = false;

            if (view.selectingLabel != null)
                view.selectingLabel.SetActive(false);

            if (view.unitProfile != null) view.unitProfile.sprite = null;
            view.assignUnit = null;
            view.unitProfile = null;
        }
    }
}
