using UnityEngine;
using UnityEngine.EventSystems;
using DefaultNamespace;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler, IDropHandler
{
    
    [SerializeField] private Canvas canvas;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    public Vector3 defaultPos;
    public bool dropped_on_slot;

    public NpcId npc_id = NpcId.None;

    private void Start()
    {
        defaultPos = GetComponent<RectTransform>().localPosition;
    }
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("On Pointer Down");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        _canvasGroup.alpha = .6f;
        _canvasGroup.blocksRaycasts = false;
        eventData.pointerDrag.GetComponent<DragAndDrop>().dropped_on_slot = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        if (dropped_on_slot == false)
        {
            GetComponent<RectTransform>().transform.position = defaultPos - new Vector3(-947.9996f,-434f,0f);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        _rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnDrop(PointerEventData eventData)
    {
      
    }
}
