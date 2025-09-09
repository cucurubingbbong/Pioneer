using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UnitSelectHandler : MonoBehaviour
{
    public GameObject unitUIPrefab;   // 유닛 UI 프리팹 (Inspector에서 할당)
    public GameObject unitListParent; // UI 부모 오브젝트 
    public GameObject[] unitUIList = null;

    public GameObject[] battleSlot = null; // 유닛 슬롯 오브젝트


    private void OnEnable()
    {
        SceneEventManager.SceneStartEvent += SettingUnitUI;
    }

    private void OnDisable()
    {
        SceneEventManager.SceneStartEvent -= SettingUnitUI;
    }

    

    /// <summary>
    /// 씬 진입시 플레이어 사무소에서 선택 가능한 유닛 불러오기
    /// </summary>
    public void SettingUnitUI()
    {
        unitUIList = new GameObject[PlayerOffiece.Instance.playerUnits.Count];

        for (int i = 0; i < PlayerOffiece.Instance.playerUnits.Count; i++)
        {
            // 프리팹 생성
            GameObject unitViewUi = Instantiate(unitUIPrefab, unitListParent.transform);
            unitUIList[i] = unitViewUi;

            // UI 이름 설정
            unitViewUi.name = PlayerOffiece.Instance.playerUnits[i].unitName;

            // 유닛 이미지 설정
            Image unitViewObjImg = unitViewUi.transform.Find("UnitImg").GetComponent<Image>();
            unitViewObjImg.sprite = PlayerOffiece.Instance.playerUnits[i].m_unitSpriteData.unitPortrait;
        }
    }

    public void AssignBattleUnit()
    {
        for (int i = 0; i < 6; i++)
        {
            if (battleSlot[i].transform.childCount < 3) continue;
            string unitName = battleSlot[i].transform.GetChild(2).gameObject.name;

            foreach (var unit in PlayerOffiece.Instance.playerUnits)
            {
                if (unit.unitName == unitName)
                {
                    PlayerOffiece.Instance.officeBattleUnits[i] = unit;
                }
            }
        }

        SceneManager.LoadScene("Battle");
    }
}
