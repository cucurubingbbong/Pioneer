using NUnit.Framework;
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

    public void AssignUnit(Unit unit)
    {
        officeUnit.Add(unit);
    }

    public void DeleteUnit(Unit unit)
    {
        officeUnit.Remove(unit);
    }
}
