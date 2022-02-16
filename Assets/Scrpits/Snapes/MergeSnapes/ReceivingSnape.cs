using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReceivingSnape : MergeSnape, IPointerClickHandler
{
    public static event Action<ReceivingSnape> ReceinSnapePointerClickEv;

    public void Merge(IncomingSnape snape)
    {
        hasMerged = true;
        snape.Merge(this);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (hasMerged) return;

        ReceinSnapePointerClickEv?.Invoke(this);

    }
}
