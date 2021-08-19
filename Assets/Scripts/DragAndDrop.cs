using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler, IDropHandler
{
    
    [SerializeField] private Canvas canvas;
    private RectTransform rect_transform;
    private CanvasGroup canvas_group;
    public Vector3 defaultPos;
    public bool dropped_on_slot;

    private void Start()
    {
        defaultPos = GetComponent<RectTransform>().localPosition;
    }
    
    private void Awake()
    {
        rect_transform = GetComponent<RectTransform>();
        canvas_group = GetComponent<CanvasGroup>();
        //defaultPos = GetComponent<RectTransform>().localPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("On Pointer Down");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvas_group.alpha = .6f;
        canvas_group.blocksRaycasts = false;
        eventData.pointerDrag.GetComponent<DragAndDrop>().dropped_on_slot = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvas_group.alpha = 1f;
        canvas_group.blocksRaycasts = true;
        if (dropped_on_slot == false)
        {
            GetComponent<RectTransform>().transform.position = defaultPos - new Vector3(-947.9996f,-434f,0f);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rect_transform.anchoredPosition += eventData.delta;
    }

    public void OnDrop(PointerEventData eventData)
    {
      
    }
}
