using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level storage", menuName = "Create storage", order = 51)]
public class LevelsStorage : ScriptableObject
{
    [SerializeField] private List<Level> allLevels;

    public Level GetLevel(int index)
    {
        index = Mathf.Clamp(index, 0, allLevels.Count - 1);
        return allLevels[index];
    }


    public int GetLevelCount()
    {
        return allLevels.Count;
    }
}
