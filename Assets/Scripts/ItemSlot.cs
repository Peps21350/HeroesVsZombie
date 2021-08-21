using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public NpcId current_selected = NpcId.NONE;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag == null)
            return;
        
        var npc_script = eventData.pointerDrag.GetComponent<DragAndDrop>();

        npc_script.dropped_on_slot = true;
        if (current_selected != NpcId.NONE)
            GameManager.selected_npc.Remove(current_selected);

        GameManager.selected_npc.Add(npc_script.npc_id);
        //Debug.Log($"{GameManager.selected_npc}");

        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
            GetComponent<RectTransform>().anchoredPosition + new Vector2(45.41586f, -201.6754f);
    }
}
