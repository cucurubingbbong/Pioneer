using UnityEngine;
using UnityEngine.EventSystems;

public class UnitPannel : MonoBehaviour , IDropHandler
{
    public GameObject unitlistParent = null;
    public void OnDrop(PointerEventData eventData)
    {
        UnitSetDrag.draggingUnit.transform.SetParent(unitlistParent.transform);
        //UnitSetDrag.draggingUnit.transform.position = transform.position;
    }
}
