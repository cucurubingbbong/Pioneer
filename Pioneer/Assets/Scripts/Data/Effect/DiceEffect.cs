using UnityEngine;

/// <summary>
/// �ֻ��� ����Ʈ ���� �߻�Ŭ���� ( ScriptableObject ���赵 )
/// </summary>
public abstract class DiceEffect : ScriptableObject
{
    public abstract void Apply(UnitBase caster, UnitBase target, int value);
}


