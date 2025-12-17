using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


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

    /// <summary>
    /// 전투 유닛 Ui 세팅 / OfficeManager.Instance.battleUnit[i] -> 이거 가독성 좋게 수정
    /// </summary>
    void BattleUnitSetting()
    {
        for (int i = 0; i < assignUnitView.Length; i++)
        {
            if (OfficeManager.Instance.battleUnit[i] == null) continue;
            assignUnitView[i].isBattleUi = true; // battle 슬롯은 선택 로직을 건너뛰게 먼저 설정
            assignUnitView[i].Setting(OfficeManager.Instance.battleUnit[i]);
        }
    }
    

}
