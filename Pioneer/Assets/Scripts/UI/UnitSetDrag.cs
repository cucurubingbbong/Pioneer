using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UnitSetDrag : MonoBehaviour , IBeginDragHandler , IDragHandler , IEndDragHandler
{
    /// <summary>
    /// �巡���ϰ��ִ� ���ӿ�����Ʈ
    /// </summary>
    public static GameObject draggingUnit = null;

    /// <summary>
    /// �����ġ
    /// </summary>
    Vector3 startPosition = Vector3.zero;

    /// <summary>
    /// ������ �ƴѰ��� ������ �ٽ� �ǵ��ƿ� Parent RectTransform
    /// </summary>
    Transform startParent = null;
    /// <summary>
    /// �巡���� ��ġ�� Parent
    /// </summary>
    [SerializeField] public Transform onDragParent;

    private void OnEnable()
    {
        GameObject PannelObj = GameObject.Find("Panel");
        onDragParent = PannelObj.transform;
    }

    /// <summary>
    /// �巡�� ���� 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        draggingUnit = gameObject;

        // ���� ��ġ , ���� �θ� ��� 
        startPosition = transform.position;
        startParent = transform.parent;

        // Drop�̺�Ʈ�� ���������� �����ϱ� ���� Icon ��Ʈ Ʈ������ ���� 
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
