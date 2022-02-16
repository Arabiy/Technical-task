using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IncreaeSnape : BonusSnape, IPointerClickHandler
{
    public static event Action BonusUsedEv;
    public override void UseEffect(MergeSnape snape)
    {
        if (!selected) return;

        if (snape is ReceivingSnape)
        {
            usedEffect = true;
            snape.SetSize(snape.Size + 1);
            Unselect();
            BonusUsedEv?.Invoke();
        }
    }
}
