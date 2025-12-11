using UnityEngine;
using UnityEngine.UI;

public class SettingUnitView : MonoBehaviour
{
    public Image unitProfile = null;

    public Unit assignUnit = null;

    public int index = 0;

    public SetBattleUnitUI sUi = null;

    bool isBattleUi = false;

    bool isSelecting = false;

    public void Setting(Unit unit)
    {
        unitProfile = GetComponentInChildren<Image>();

        assignUnit = unit;
    }

    public void OpenUnitSet()
    {
        if (!isBattleUi) return;
        sUi.currentIndex = index;
        UIManager.Instance.ShowScreen(UIScreenType.UnitSet);
    }

    public void Select()
    {
        if (isBattleUi) return;
        OfficeManager.Instance.battleUnit[sUi.currentIndex] = assignUnit;
    }

    


}