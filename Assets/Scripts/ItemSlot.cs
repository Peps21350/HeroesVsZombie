using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        eventData.pointerDrag.GetComponent<DragAndDrop>().dropped_on_slot = true;
        //eventData.pointerDrag.GetComponent<DragAndDrop>().defaultPos = transform.position;
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition +  new Vector2(45.41586f,-201.6754f);
        }
    }
}
