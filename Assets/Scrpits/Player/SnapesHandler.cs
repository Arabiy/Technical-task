using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapesHandler : MonoBehaviour
{
    [SerializeField] private IncomingSnape incominggSnape;
    [SerializeField] private BonusSnape bonusSnape;

    public event Action<bool> MovedEv;

    public void OnIncomingClick(IncomingSnape snape)
    {
        if (incominggSnape != null)
        {
            if (incominggSnape == snape)
            {
                CleadIncomingSnape();
                return;
            }

            incominggSnape.Unselect();
        }


        incominggSnape = snape;
        incominggSnape.Select();

    }
    public void OnBonusClick(BonusSnape snape)
    {
        if (bonusSnape != null)
        {
            if (bonusSnape == snape)
            {
                ClearBonusSnape();
                return;
            }

            bonusSnape.Unselect();
        }

        CleadIncomingSnape();

        bonusSnape = snape;
        bonusSnape.Select();
    }
    public void OnReceivingClick(ReceivingSnape snape)
    {
        if (incominggSnape == null) return;

        bool successfulMove = false;

        if (incominggSnape.Size <= snape.Size)
        {
            incominggSnape.Unselect();

            MergeSnapes(incominggSnape, snape);
            successfulMove = true;
        }

        MovedEv?.Invoke(successfulMove);
    }

    private void MergeSnapes(IncomingSnape incomingSnape, ReceivingSnape receivingSnape)
    {
        incomingSnape.Merge(receivingSnape);
        receivingSnape.Merge(incomingSnape);
        CleadIncomingSnape();
    }


    private void CleadIncomingSnape()
    {
        if (incominggSnape == null) return;

        incominggSnape.Unselect();
        incominggSnape = null;
    }
    private void ClearBonusSnape()
    {
        if (bonusSnape == null) return;

        bonusSnape.Unselect();
        bonusSnape = null;
    }

    private void ClearAll()
    {
        CleadIncomingSnape();
        ClearBonusSnape();
    }

    private void OnGameStart()
    {
        ClearAll();
    }

    #region OnEnable & OnDisable

    private void OnEnable()
    {
        ReceivingSnape.ReceinSnapePointerClickEv += OnReceivingClick;
        IncomingSnape.IncomingSnapePointerClickEv += OnIncomingClick;
        ReducingSnape.BonusClickEv += OnBonusClick;
        GameStarter.StartGameEv += OnGameStart;

        IncreaeSnape.BonusUsedEv += ClearAll;
        ReducingSnape.BonusUsedEv += ClearAll;
    }

    private void OnDisable()
    {
        ReceivingSnape.ReceinSnapePointerClickEv -= OnReceivingClick;
        IncomingSnape.IncomingSnapePointerClickEv -= OnIncomingClick;
        ReducingSnape.BonusClickEv -= OnBonusClick;
        GameStarter.StartGameEv -= OnGameStart;

        IncreaeSnape.BonusUsedEv -= ClearAll;
        ReducingSnape.BonusUsedEv -= ClearAll;
    }
    #endregion
}
