using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsGenerator : MonoBehaviour
{
    [SerializeField] private Transform buttonContainer;
    [SerializeField, Space] private LevelButton buttonPrefab;
    [SerializeField, Space] private LevelsStorage storage;
    [SerializeField] private GameObject levelsPanel;

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        GameStarter levelStarer = FindObjectOfType<GameStarter>();

        int buttonsCount = storage.GetLevelCount();

        for (int i = 0; i < buttonsCount; i++)
        {
            var newBt = Instantiate(buttonPrefab, buttonContainer);
            newBt.Init(i, levelsPanel, levelStarer);
        }
    }

    public void Clean()
    {

    }

    

}
