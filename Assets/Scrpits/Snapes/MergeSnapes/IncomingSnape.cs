using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;
using UnityEngine.EventSystems;
using System;

public class IncomingSnape : MergeSnape, ISelectable, IPointerClickHandler
{
    [Header("IncominSnape")]
    [SerializeField] private GameObject bgSprite;
    public static event Action<IncomingSnape> IncomingSnapePointerClickEv;
 

    public void Select()
    {
        bgSprite.SetActive(true);
    }
    public void Unselect()
    {
        bgSprite.SetActive(false);
    }

    public void Merge(ReceivingSnape snape)
    {
        hasMerged = true;
        transform.DOMove(snape.transform.position, 0.3f).SetEase(Ease.InOutQuad);
        transform.DOScale(snape.Size/10f, 0.3f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!hasMerged)
        {
            IncomingSnapePointerClickEv?.Invoke(this);
        }
    }
}
