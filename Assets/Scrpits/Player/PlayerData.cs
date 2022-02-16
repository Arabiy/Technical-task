using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int FailedMoves { get; private set; }
    public int SuccessfallMoves { get; private set; }
    public int MovesCount { get; private set; }

    private ActionsDataDisplayer actionsDataDisplayer;

    private SnapesHandler snapesHandler;
    private void Awake()
    {
        snapesHandler = FindObjectOfType<SnapesHandler>();
        actionsDataDisplayer = FindObjectOfType<ActionsDataDisplayer>();

        actionsDataDisplayer.UpdateUi(MovesCount, SuccessfallMoves);
    }



    public void OnMoved(bool successfulMove)
    {
        MovesCount++;

        if (successfulMove)
        {
            SuccessfallMoves++;
        }
        else
        {
            FailedMoves++;
        }

        actionsDataDisplayer.UpdateUi(MovesCount, SuccessfallMoves);
    }
    public void ResetData()
    {
        FailedMoves = 0;
        SuccessfallMoves = 0;
        MovesCount = 0;

        actionsDataDisplayer.UpdateUi(MovesCount, SuccessfallMoves);
    }
    public void StartGame()
    {
        ResetData();
    }

    
    #region OnEnable & OnDisable

    private void OnEnable()
    {
        snapesHandler.MovedEv += OnMoved;
        GameStarter.StartGameEv += ResetData;
    }

    private void OnDisable()
    {
        snapesHandler.MovedEv -= OnMoved;
        GameStarter.StartGameEv -= ResetData;
    }
    #endregion
}
