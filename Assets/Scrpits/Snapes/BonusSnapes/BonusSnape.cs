using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BonusSnape : Snape, ISelectable, IPointerClickHandler
{
    [SerializeField] private GameObject bg = null;

    [SerializeField] protected bool usedEffect = false;
    [SerializeField] protected bool selected = false;

    public static event Action<BonusSnape> BonusClickEv;


    public void Select()
    {
        selected = true;
        bg.gameObject.SetActive(true);
    }
    public void Unselect()
    {
        selected = false;
        bg.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (usedEffect) return;
        BonusClickEv?.Invoke(this);
    }

    public abstract void UseEffect(MergeSnape snape);

    #region OnEnable & OnDisable

    private void OnEnable()
    {
        IncomingSnape.IncomingSnapePointerClickEv += UseEffect;
        ReceivingSnape.ReceinSnapePointerClickEv += UseEffect;
    }

    private void OnDisable()
    {
        IncomingSnape.IncomingSnapePointerClickEv -= UseEffect;
        ReceivingSnape.ReceinSnapePointerClickEv -= UseEffect;
    }
    #endregion
}
