using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private int index;
    [SerializeField] private TMPro.TextMeshProUGUI text; //в ином случаи создал бы класс ButtonDisplayer
    public void Init(int index, GameObject levelsPanel, GameStarter levelStarter)
    {
        this.index = index;
        text.text = (1 + index).ToString();

        button.onClick.AddListener(() =>
        {
            levelStarter.SetLevelIndex(this.index);
            levelStarter.StartGame();
            levelsPanel.SetActive(false);
        });
    }

}
