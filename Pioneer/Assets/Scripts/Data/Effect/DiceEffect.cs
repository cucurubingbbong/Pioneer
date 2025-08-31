using UnityEngine;

/// <summary>
/// 주사위 이펙트 적용 추상클래스 ( ScriptableObject 설계도 )
/// </summary>
public abstract class DiceEffect : ScriptableObject
{
    public abstract void Apply(UnitBase caster, UnitBase target, int value);
}


