using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class BattleUnitUI : MonoBehaviour
{
    /// <summary>
    /// 할당된 전투 유닛 프로필
    /// </summary>

    [SerializeField] SettingUnitView[] assignUnit = new SettingUnitView[6];

    private void OnEnable()
    {
        BattleUnitSetting();
    }

    /// <summary>
    /// 전투 유닛 Ui 세팅 / OfficeManager.Instance.battleUnit[i] -> 이거 가독성 좋게 수정
    /// </summary>
    void BattleUnitSetting()
    {
        for (int i = 0; i < assignUnit.Length; i++)
        {
            if (OfficeManager.Instance.battleUnit[i] == null) return;
            assignUnit[i].Setting(OfficeManager.Instance.battleUnit[i]);
            assignUnit[i].unitProfile.sprite = OfficeManager.Instance.battleUnit[i].unitResource.portrait;
        }
    }
    

}
