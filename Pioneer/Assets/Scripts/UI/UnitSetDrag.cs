using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UnitSetDrag : MonoBehaviour , IBeginDragHandler , IDragHandler , IEndDragHandler
{
    /// <summary>
    /// 드래그하고있는 게임오브젝트
    /// </summary>
    public static GameObject draggingUnit = null;

    /// <summary>
    /// 백업위치
    /// </summary>
    Vector3 startPosition = Vector3.zero;

    /// <summary>
    /// 슬롯이 아닌곳에 놓을시 다시 되돌아올 Parent RectTransform
    /// </summary>
    Transform startParent = null;
    /// <summary>
    /// 드래그중 위치할 Parent
    /// </summary>
    [SerializeField] public Transform onDragParent;

    private void OnEnable()
    {
        GameObject PannelObj = GameObject.Find("Panel");
        onDragParent = PannelObj.transform;
    }

    /// <summary>
    /// 드래그 시작 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingUnit = gameObject;

        // 시작 위치 , 시작 부모 백업 
        startPosition = transform.position;
        startParent = transform.parent;

        // Drop이벤트를 정상적으로 감지하기 위해 Icon 렉트 트랜스폼 무시 
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(onDragParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggingUnit = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (transform.parent == onDragParent)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }

    }
}
