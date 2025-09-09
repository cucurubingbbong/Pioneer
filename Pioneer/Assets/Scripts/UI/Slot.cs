using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour , IDropHandler
{
    GameObject Icon()
    {
        if (transform.childCount > 2)
            return transform.GetChild(0).gameObject;
        else
            return null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (Icon() == null)
        {
            UnitSetDrag.draggingUnit.transform.SetParent(transform);
            UnitSetDrag.draggingUnit.transform.position = transform.position;
        }
    }
}