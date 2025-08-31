using UnityEngine;

public enum EffectType
{
    Damage,
}

[CreateAssetMenu(menuName = "DiceEffect/GenericEffect")]
public class GenericEffect : DiceEffect
{
    public EffectType effectType;

    public override void Apply(UnitBase caster, UnitBase target, int value)
    {
        switch (effectType)
        {
            case EffectType.Damage:
                break;
        }
    }
}
