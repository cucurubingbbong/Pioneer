using UnityEngine;

abstract class UnitBase
{
    /// <summary>
    /// 최대체력
    /// </summary>
    [SerializeField] float maxHp = 0.0f;

    /// <summary>
    /// 현재체력
    /// </summary>
    [SerializeField] float currentHp = 0.0f;

    /// <summary>
    /// 공격레벨
    /// </summary>
    [SerializeField] int attackLevel = 0;

    /// <summary>
    /// 방어레벨
    /// </summary>
    [SerializeField] int defenseLevel = 0;

    /// <summary>
    /// 속도
    /// </summary>
    [SerializeField] int speed = 0;

    /// <summary>
    /// 정신력
    /// </summary>
    [SerializeField] int mentalPower = 0;
}
