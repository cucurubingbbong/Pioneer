using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    static TurnManager Instance = null;

    public List<Unit> battleUnits = new List<Unit>();

    /// <summary>
    /// 플레이어 턴 컨트롤러
    /// </summary>
    [SerializeField] ITurnActor playerTurnController = null;

    /// <summary>
    /// 적 턴 컨트롤러
    /// </summary>
    [SerializeField] ITurnActor EnemyTurnController = null;


    /// <summary>
    /// 전투가 끝났는지
    /// </summary>
    bool isBattleEnd = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    IEnumerator BattleLoop()
    {
        while (isBattleEnd)
        {
            yield return StartCoroutine(StartTurn());
        }

        Debug.Log("전투 끝");
    }

    IEnumerator StartTurn()
    {
        List<Unit> actorUnit = new List<Unit>();
        foreach (Unit unit in battleUnits)
        {
            if(unit.currentHealth > 0) actorUnit.Add(unit); 
        }

        if (actorUnit.Count == 0)
        {
            isBattleEnd = true;
            yield break;
        }

        ArrayActionOrder(actorUnit);
        // actorUnit에서 가장 위에 있는 순서로 하나씩 뽑아서 TakeTurn 실행하기

        yield return null;
    }

    /// <summary>
    /// 속도 기반 정렬
    /// 절대 LINQ를 쓰지마
    /// 절대 Sort를 쓰지마
    /// </summary>
    /// <returns></returns>
    public void ArrayActionOrder(List<Unit> actorUnit)
    {
        if (actorUnit.Count < 2) return;

        for (int i = 0; i < actorUnit.Count - 1; i++)
        {
            for (int j = 0; j < actorUnit.Count - 1 - i; j++)
            {
                if (actorUnit[j] == null || actorUnit[j + 1] == null) continue;

                if (actorUnit[j].speed < actorUnit[j + 1].speed)
                {
                    (actorUnit[j], actorUnit[j + 1]) = (actorUnit[j + 1], actorUnit[j]);
                }
            }
        }
    }

}
