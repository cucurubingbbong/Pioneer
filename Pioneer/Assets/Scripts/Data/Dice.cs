using UnityEngine;

/// <summary>
/// ¡÷ªÁ¿ß
/// </summary>
[System.Serializable]
public class Dice
{
    public int minValue = 0;
    public int maxValue = 0;

    public bool isBroken = false;


    public void Break()
    {
        isBroken = true;
    }


    [SerializeField]
    public DiceEffect effect;

    public void Apply(UnitBase caster, UnitBase target, int value)
    {
        if (isBroken) return;
        effect?.Apply(caster, target, value);
    }


}