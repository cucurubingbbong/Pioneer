using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SetBattleUnitUI : MonoBehaviour
{
    [SerializeField] GameObject battleUnitUi = null;

    [SerializeField] Transform placeUiTrans = null;

    [SerializeField] List<GameObject> currentPageObj = new List<GameObject>();

    /// <summary>
    /// 현재 선택된 편성순서
    /// </summary>
    public int currentIndex = 0;

    private void OnEnable()
    {
        SettingPage(1);
    }

    private void OnDisable()
    {
        DeletePage();
    }

    void SettingPage(int pageIndex)
    {
        const int pageSize = 10;
        int start = Mathf.Max(0, (pageIndex - 1) * pageSize);
        int end = Mathf.Min(start + pageSize, OfficeManager.Instance.officeUnit.Count);

        for (int i = start; i < end; i++)
        {
            GameObject obj = Instantiate(battleUnitUi, placeUiTrans);
            currentPageObj.Add(obj);
            SettingUnitView bi = obj.GetComponent<SettingUnitView>();
            bi.isBattleUi = false;
            bi.Setting(OfficeManager.Instance.officeUnit[i]);
        }
    }

    void DeletePage()
    {
        foreach (GameObject obj in currentPageObj)
        {
            Destroy(obj);
        }

        currentPageObj = new List<GameObject>();
    }
}
