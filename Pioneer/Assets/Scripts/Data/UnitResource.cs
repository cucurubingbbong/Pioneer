using UnityEngine;

[CreateAssetMenu(fileName = "UnitResource", menuName = "UnitData/UnitResource")]
public class UnitResource : ScriptableObject
{
    [Header("UI용 리소스")]
    public Sprite portrait; // 프로필
    public Sprite miniIcon; // 턴 아이콘

    [Header("스탠딩 / 전투 외형")]
    public GameObject standingPrefab;   // 스탠딩 프리팹 
    public RuntimeAnimatorController animatorController;
}
