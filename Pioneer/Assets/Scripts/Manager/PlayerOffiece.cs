using System.Collections.Generic;
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
    /// ���ֵ� ��� 
    /// </summary>
    public List<UnitBase> playerUnits = new List<UnitBase>();

    /// <summary>
    /// �������� ����
    /// </summary>
    public UnitBase[] officeBattleUnits = null;

    /// <summary>
    /// ���� ������ ( SO )
    /// </summary>
    public List <UnitData> playerData = new List<UnitData>();

    private void Start()
    {
        if (playerData.Count == 0)
        {
            foreach (var unit in playerData)
            {
                playerUnits.Add(new UnitBase(unit));
            }
        }
    }

    
}
