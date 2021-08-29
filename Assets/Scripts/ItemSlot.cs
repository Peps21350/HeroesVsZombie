using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public NpcId current_selected = NpcId.None;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag == null)
            return;
        
        var npcScript = eventData.pointerDrag.GetComponent<DragAndDrop>();

        npcScript.dropped_on_slot = true;
        if (current_selected != NpcId.None)
            GameManager.SelectedNpc.Remove(current_selected);

        GameManager.SelectedNpc.Add(npcScript.npc_id);
        //Debug.Log($"{GameManager.selected_npc}");

        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
            GetComponent<RectTransform>().anchoredPosition + new Vector2(45.41586f, -201.6754f);
    }
}
