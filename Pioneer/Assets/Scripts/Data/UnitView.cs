using UnityEngine;

public class UnitView : MonoBehaviour
{
    public SpriteRenderer unitSprite = null;

    public Sprite unitStandSprite = null;

    void GetUnitSprite()
    {
        unitSprite.sprite = unitStandSprite;
    }
}
