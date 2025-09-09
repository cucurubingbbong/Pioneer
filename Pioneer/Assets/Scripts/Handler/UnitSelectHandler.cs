using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UnitSelectHandler : MonoBehaviour
{
    public GameObject unitUIPrefab;   // 유닛 UI 프리팹 (Inspector에서 할당)
    public GameObject unitListParent; // UI 부모 오브젝트 
    public GameObject[] unitUIList = null;

    public GameObject dragUnit = null; // 드래그 하고 있는 유닛

    public Vector3 offset = Vector3.zero; // 마우스와 유닛 오브젝트 사이의 거리

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
}
