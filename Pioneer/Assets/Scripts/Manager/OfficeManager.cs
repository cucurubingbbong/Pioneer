using System.Collections.Generic;
using UnityEngine;

public class OfficeManager : MonoBehaviour
{
    public static OfficeManager Instance { get; private set; }

    /// <summary>
    /// 돈
    /// </summary>
    public int money;

    /// <summary>
    /// 사무소 레벨
    /// </summary>
    public int officeLevel;

    /// <summary>
    /// 사무소 유닛
    /// </summary>
    public List<Unit> officeUnit = new List<Unit>();

    /// <summary>
    /// 전투 편성 유닛 
    /// </summary>
    public Unit[] battleUnit = new Unit[6];

    /// <summary>
    /// 현재 할당된 임무
    /// </summary>
    public List<Quest> quest = new List<Quest>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    /// <summary>
    /// 유닛 할당
    /// </summary>
    /// <param name="unit">할당할 유닛</param>
    public void AssignUnit(Unit unit)
    {
        officeUnit.Add(unit);
    }

    /// <summary>
    /// 유닛 제거
    /// </summary>
    /// <param name="unit">제거할 유닛</param>
    public void DeleteUnit(Unit unit)
    {
        officeUnit.Remove(unit);
    }

    /// <summary>
    /// 퀘스트 할당
    /// </summary>
    /// <param name="assignQuest">할당할 퀘스트</param>
    public void AssignQuest(Quest assignQuest)
    {
        quest.Add(assignQuest);
    }

    /// <summary>
    /// 퀘스트 거절
    /// </summary>
    /// <param name="denyQuest">거절할 퀘스트</param>
    public void DenyQuest(Quest denyQuest)
    {
        quest.Remove(denyQuest);
    }
}
