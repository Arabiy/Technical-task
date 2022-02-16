using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private LevelGenerator levelGenerator;


    private int currentLevelIndex = 0;


    public static event Action StartGameEv;

    private void Start()
    {
        levelGenerator = GetComponent<LevelGenerator>();
        StartGame();
    }
    public void StartGame()
    {
        StartGameEv?.Invoke();
        levelGenerator.GenerateLevel(currentLevelIndex);
    }

    public void AddIndexValue(int newIndexValue)
    {
        SetLevelIndex(currentLevelIndex += newIndexValue);
        StartGame();
    }
    public void SetLevelIndex(int value)
    {

        if (value < 0)
        {
            value = levelGenerator.GetLevelCount() -1;
        }
        else
            if (value > levelGenerator.GetLevelCount() -1)
        {
            value = 0;
        }
        currentLevelIndex = value;
    }
}
