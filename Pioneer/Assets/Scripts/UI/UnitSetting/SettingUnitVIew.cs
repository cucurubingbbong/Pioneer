using UnityEngine;
using UnityEngine.UI;

public class SettingUnitView : MonoBehaviour
{
    public Image unitProfile = null;
    public Unit assignUnit = null;
    public int index = 0;
    public SetBattleUnitUI sUi = null;
    public bool isBattleUi = false;
    public bool isSelecting = false;
    public GameObject selectingLabel = null;

    public Unit nullUnit = new Unit();

    private void OnEnable()
    {
        if (UIManager.Instance != null &&
            UIManager.Instance.screenMap.TryGetValue(UIScreenType.UnitSet, out var unitSetObj))
        {
            sUi = unitSetObj.GetComponent<SetBattleUnitUI>();
        }
    }

    /// <summary>
    /// ui 세팅
    /// </summary>
    public void Setting(Unit unit)
    {
        unitProfile = GetComponentInChildren<Image>();
        assignUnit = unit;
        if (assignUnit != null && assignUnit.unitResource != null)
        {
            unitProfile.sprite = assignUnit.unitResource.portrait;
        }
        else if (unitProfile != null)
        {
            unitProfile.sprite = null;
        }

        if (isBattleUi) return;

        if (OfficeManager.Instance == null || OfficeManager.Instance.battleUnit == null) return;
        if (sUi == null || sUi.currentIndex <= 0 || sUi.currentIndex - 1 >= OfficeManager.Instance.battleUnit.Length) return;

        if (OfficeManager.Instance.battleUnit[sUi.currentIndex - 1] == unit)
        {
            ApplySelectThis(); 
        }
    }

    /// <summary>
    /// 유닛세팅 오픈
    /// </summary>
    public void OpenUnitSet()
    {
        if (!isBattleUi) return;
        sUi.currentIndex = index;
        UIManager.Instance.ShowScreen(UIScreenType.UnitSet);
    }

    /// <summary>
    /// 선택
    /// </summary>
    public void Select()
    {
        if (isBattleUi) return;

        if (sUi == null || OfficeManager.Instance == null || OfficeManager.Instance.battleUnit == null) return;
        int slotIndex = sUi.currentIndex - 1;
        if (slotIndex < 0 || slotIndex >= OfficeManager.Instance.battleUnit.Length) return;

        ApplySelectThis(); 
        if (selectingLabel != null) selectingLabel.SetActive(true);

        OfficeManager.Instance.battleUnit[slotIndex] = assignUnit;
    }

    /// <summary>
    /// 선택 해제
    /// </summary>
    public void Deselect()
    {
        if (isBattleUi) return;

        if (sUi == null || OfficeManager.Instance == null || OfficeManager.Instance.battleUnit == null) return;
        int slot = sUi.currentIndex - 1;
        if (slot < 0 || slot >= OfficeManager.Instance.battleUnit.Length) return;

        // UI 선택 해제
        isSelecting = false;
        if (selectingLabel != null) selectingLabel.SetActive(false);

        // lastSelectUnitView 정리
        if (sUi != null && sUi.lastSelectUnitView == this)
            sUi.lastSelectUnitView = null;

        // 슬롯에서도 제거
        OfficeManager.Instance.battleUnit[slot] = nullUnit;
    }

    /// <summary>
    /// 클릭
    /// </summary>
    public void Click()
    {
        if (isBattleUi) OpenUnitSet();
        else if (!isBattleUi && isSelecting) Deselect();
        else Select();
    }

    // 선택 적용
    private void ApplySelectThis()
    {
        if (sUi != null && sUi.lastSelectUnitView != null)
        {
            sUi.lastSelectUnitView.isSelecting = false;

            if (sUi.lastSelectUnitView.selectingLabel != null)
                sUi.lastSelectUnitView.selectingLabel.SetActive(false);
        }

        if (sUi != null) sUi.lastSelectUnitView = this;
        isSelecting = true;

        if (selectingLabel != null)
            selectingLabel.SetActive(true);
    }
}
