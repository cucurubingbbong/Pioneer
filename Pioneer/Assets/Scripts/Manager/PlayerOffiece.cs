using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PlayerOffiece : MonoBehaviour
{
    public static PlayerOffiece Instance { get; private set; } = null;

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
    /// 유닛들 목록 
    /// </summary>
    public List<UnitBase> playerUnits = new List<UnitBase>();

    /// <summary>
    /// 전투가능 유닛
    /// </summary>
    public UnitBase[] officeBattleUnits = new UnitBase[6];

    /// <summary>
    /// 유닛 데이터 ( SO )
    /// </summary>
    public List <UnitData> playerData = new List<UnitData>();

    private void Start()
    {
        LoadUnit();
    }

    public void LoadUnit()
    {
        if (playerUnits.Count == 0)
        {
            foreach (var unit in playerData)
            {
                playerUnits.Add(new UnitBase(unit));
            }

        }

        SceneEventManager.TriggerSceneStart();
    }

    
}
