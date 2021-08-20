using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public List<bool> taked_heroes = new List<bool>(); 
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        eventData.pointerDrag.GetComponent<DragAndDrop>().dropped_on_slot = true;
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition +  new Vector2(45.41586f,-201.6754f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Infantryman"))
        {
            taked_heroes[0] = true;
        }
        else
        {
            taked_heroes[0] = false;
        }
        
        if (other.gameObject.CompareTag("Robot1"))
        {
            taked_heroes[1] = true;
        }
        else
        {
            taked_heroes[1] = false;
        }
        
        if (other.gameObject.CompareTag("Robot2"))
        {
            taked_heroes[2] = true;
        }
        else
        {
            taked_heroes[2] = false;
        }
        
        if (other.gameObject.CompareTag("Infantryman2"))
        {
            taked_heroes[3] = true;
        }
        else
        {
            taked_heroes[3] = false;
        }
    }


    /*private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Infantryman"))
        {
            taked_heroes[0] = true;
        }
        else
        {
            taked_heroes[0] = false;
        }
        
        if (other.gameObject.CompareTag("Robot1"))
        {
            taked_heroes[1] = true;
        }
        else
        {
            taked_heroes[1] = false;
        }
        
        if (other.gameObject.CompareTag("Robot2"))
        {
            taked_heroes[2] = true;
        }
        else
        {
            taked_heroes[2] = false;
        }
        
        if (other.gameObject.CompareTag("Infantryman2"))
        {
            taked_heroes[3] = true;
        }
        else
        {
            taked_heroes[3] = false;
        }
        
    }*/
}
