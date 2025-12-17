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

    private void OnEnable()
    {
        GameObject unitSetObj = UIManager.Instance.screenMap[UIScreenType.UnitSet];
        sUi = unitSetObj.GetComponent<SetBattleUnitUI>();
    }

    /// <summary>
    /// ui 세팅
    /// </summary>
    /// <param name="unit">할당받은 유닛</param>
    public void Setting(Unit unit)
    {
        unitProfile = GetComponentInChildren<Image>();
        assignUnit = unit;
        unitProfile.sprite = assignUnit.unitResource.portrait;

        if (isBattleUi) return;
        if (OfficeManager.Instance.battleUnit[sUi.currentIndex - 1] == unit)
        {
            sUi.lastSelectUnitView.selectingLabel.SetActive(false);
            sUi.lastSelectUnitView = this;
            isSelecting = true;
            selectingLabel.SetActive(true);
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
        isSelecting = true;
        selectingLabel.SetActive(true);
        OfficeManager.Instance.battleUnit[sUi.currentIndex-1] = assignUnit;
    }

    /// <summary>
    /// 클릭
    /// </summary>
    public void Click()
    {
        if (isBattleUi)
        {
            OpenUnitSet();
        }
        else Select();

    }

    


}
