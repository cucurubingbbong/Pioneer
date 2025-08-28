using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 날짜
    /// </summary>
    public int Day = 0;

    /// <summary>
    /// 유닛들 목록 
    /// </summary>
    public List<UnitBase> PlayerUnits = new List<UnitBase>();
}
