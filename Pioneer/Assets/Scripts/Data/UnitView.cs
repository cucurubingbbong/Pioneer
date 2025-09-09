using UnityEngine;

public class UnitView : MonoBehaviour
{
    public SpriteRenderer unitSprite = null;

    public Sprite unitStandSprite = null;

    public void GetUnitSprite()
    {
        if(unitSprite != null && unitStandSprite !=null) unitSprite.sprite = unitStandSprite;
    }
}
