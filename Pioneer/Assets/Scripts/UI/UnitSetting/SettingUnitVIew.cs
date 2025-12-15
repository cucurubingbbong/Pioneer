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

    private void OnEnable()
    {
        GameObject unitSetObj = UIManager.Instance.screenMap[UIScreenType.UnitSet];
        sUi = unitSetObj.GetComponent<SetBattleUnitUI>();
    }

    public void Setting(Unit unit)
    {
        unitProfile = GetComponentInChildren<Image>();
        assignUnit = unit;
        unitProfile.sprite = assignUnit.unitResource.portrait;
    }

    public void OpenUnitSet()
    {
        if (!isBattleUi) return;
        UIManager.Instance.ShowScreen(UIScreenType.UnitSet);
        sUi.currentIndex = index;
    }

    public void Select()
    {
        if (isBattleUi) return;
        OfficeManager.Instance.battleUnit[sUi.currentIndex] = assignUnit;
    }

    public void Click()
    {
        if (isBattleUi)
        {
            OpenUnitSet();
        }
        else Select();

    }

    


}
