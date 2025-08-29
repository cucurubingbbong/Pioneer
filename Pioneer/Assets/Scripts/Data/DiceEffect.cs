using UnityEngine;

/// <summary>
/// �ֻ���
/// </summary>
[System.Serializable]
public class Dice
{
    public int minValue = 0;
    public int maxValue = 0;

    [SerializeField]
    public DiceEffect effect;

    public void Apply(UnitBase caster, UnitBase target, int value)
    {
        effect?.Apply(caster, target, value);
    }


}

/// <summary>
/// �ֻ��� ����Ʈ ���� �߻�Ŭ���� ( ���赵 )
/// </summary>
public abstract class DiceEffect : ScriptableObject
{
    public abstract void Apply(UnitBase caster, UnitBase target, int value);
}

[CreateAssetMenu(menuName = "DiceEffect/DamageEffect")]
public class DamageEffect : DiceEffect 
{
    public override void Apply(UnitBase caster, UnitBase target, int value)
    {
    }
}




