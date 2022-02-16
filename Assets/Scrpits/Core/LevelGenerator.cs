using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField, Space] private Transform snapesParent;
    [SerializeField] private LevelsStorage levelsStorage;

    public void GenerateLevel(int index)
    {
        ClearSnapes();

        var currentLevel = levelsStorage.GetLevel(index);


        GenerateMergeSnapes(currentLevel.GetMergeSnapes());
        GenerateBonusSnapes(currentLevel.GetBonusSnape());
        FindObjectOfType<PlayerEnergy>().Init(currentLevel.GetBonusSnape().energyCount);

    }

    public void GenerateMergeSnapes(IList<MergeSnapesInLevel> mergeSnapes)
    {
        if (mergeSnapes.Count == 0) return;

        for (int i = 0; i < mergeSnapes.Count; i++)
        {
            CreateSnape(mergeSnapes[i].IncomingSnape, mergeSnapes[i].IncomingSnape.Size);
            CreateSnape(mergeSnapes[i].ReceivingSnape, mergeSnapes[i].ReceivingSnape.Size);
        }
    }
    private void GenerateBonusSnapes(BonusSnapes bonusSnape)
    {
        if (bonusSnape.BonusSnapesInLevel.Count == 0) return;

        var snapes = bonusSnape.BonusSnapesInLevel;

        for (int i = 0; i < snapes.Count; i++)
        {
            CreateSnape(snapes[i], 10);
        }
    }

    public void CreateSnape(SnapeInLevel snapesInLevel, int size)
    {
        var newSnape = Instantiate(snapesInLevel.Snape, snapesParent);
        newSnape.transform.position = new Vector3(snapesInLevel.PositionX, snapesInLevel.PositionY, 0f);
        newSnape.SetSize(size);
    }

    public void ClearSnapes()
    {
        foreach (Transform item in snapesParent)
        {
            Destroy(item.gameObject);
        }
    }

    public int GetLevelCount()
    {
        return levelsStorage.GetLevelCount();
    }
}
