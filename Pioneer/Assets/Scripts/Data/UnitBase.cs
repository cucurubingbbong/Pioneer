using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class UnitBase
{
    /// <summary>
    /// 유닛이름
    /// </summary>
    public string unitName = null;

    /// <summary>
    /// 스킬 리스트
    /// </summary>
    public List<Skill> skillList = new List<Skill>();
    /// <summary>
    /// 최대체력
    /// </summary>
    public float maxHp = 0.0f;

    /// <summary>
    /// 현재체력
    /// </summary>
    public float currentHp = 0.0f;

    /// <summary>
    /// 공격레벨
    /// </summary>
    public int attackLevel = 0;

    /// <summary>
    /// 방어레벨
    /// </summary>
    public int defenseLevel = 0;

    /// <summary>
    /// 속도
    /// </summary>
    public int speed = 0;

    /// <summary>
    /// 정신력
    /// </summary>
    public int mentalPower = 0;
}
