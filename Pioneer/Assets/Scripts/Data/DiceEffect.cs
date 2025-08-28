using UnityEngine;

/// <summary>
/// ¡÷ªÁ¿ß
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

public abstract class DiceEffect : ScriptableObject
{
    public abstract void Apply(UnitBase caster, UnitBase target, int value);
}

[CreateAssetMenu(menuName = "DiceEffect/DamageEffect")]
[System.Serializable]
public class DamageEffect : DiceEffect 
{
    public override void Apply(UnitBase caster, UnitBase target, int value)
    {
    }
}




