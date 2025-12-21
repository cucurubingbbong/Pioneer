using System.Collections.Generic;
using UnityEngine;

public class SetBattleUnitUI : MonoBehaviour
{
    [SerializeField] GameObject battleUnitUi = null;

    [SerializeField] Transform placeUiTrans = null;

    [SerializeField] List<GameObject> currentPageObj = new List<GameObject>();

    /// <summary>
    /// 마지막으로 선택된 유닛뷰 ui
    /// </summary>
    public SettingUnitView lastSelectUnitView = null;

    /// <summary>
    /// 현재 선택된 편성순서
    /// </summary>
    public int currentIndex = 0;

    private void OnEnable()
    {
        currentIndex = Mathf.Max(1, currentIndex);
        SettingPage(1);
    }

    private void OnDisable()
    {
        DeletePage();
    }

    /// <summary>
    /// 선택화면 세팅
    /// </summary>
    /// <param name="pageIndex">페이지번호</param>
    void SettingPage(int pageIndex)
    {
        if (battleUnitUi == null || placeUiTrans == null) return;
        if (OfficeManager.Instance == null || OfficeManager.Instance.officeUnit == null || OfficeManager.Instance.battleUnit == null) return;
        if (currentIndex <= 0) currentIndex = 1;

        const int pageSize = 10;
        int start = Mathf.Max(0, (pageIndex - 1) * pageSize);
        int end = Mathf.Min(start + pageSize, OfficeManager.Instance.officeUnit.Count);

        for (int i = start; i < end; i++)
        {
            bool alreadyInBattle = false;

            foreach (var unit in OfficeManager.Instance.battleUnit)
            {
                if (unit == OfficeManager.Instance.officeUnit[i])
                {
                    if (currentIndex - 1 >= 0 && currentIndex - 1 < OfficeManager.Instance.battleUnit.Length
                        && unit == OfficeManager.Instance.battleUnit[currentIndex - 1]) continue;
                    alreadyInBattle = true;
                    break;
                }


            }

            if (alreadyInBattle) continue; 

            GameObject obj = Instantiate(battleUnitUi, placeUiTrans);
            currentPageObj.Add(obj);

            SettingUnitView bi = obj.GetComponent<SettingUnitView>();
            if (bi == null) continue;
            bi.isBattleUi = false;
            bi.Setting(OfficeManager.Instance.officeUnit[i]);
        }

    }

    /// <summary>
    /// 페이지 초기화
    /// </summary>
    void DeletePage()
    {
        foreach (GameObject obj in currentPageObj)
        {
            Destroy(obj);
        }

        currentPageObj = new List<GameObject>();
    }
}
