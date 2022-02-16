using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Create new level", order = 51)]
public class Level : ScriptableObject
{
    [SerializeField] private List<MergeSnapesInLevel> mergeSnapes;
    [SerializeField] private BonusSnapes bonusSnapes;


    public List<SnapeInLevel> GetAllSnapes()
    {
        List<SnapeInLevel> allSnapes = new List<SnapeInLevel>(AllSnapesCount());

        foreach (var item in mergeSnapes)
        {
            allSnapes.Add(item.IncomingSnape);
            allSnapes.Add(item.ReceivingSnape);
        }

        if (GetBonusSnapesCount() > 0)
        {
            foreach (var item in bonusSnapes.BonusSnapesInLevel)
            {
                allSnapes.Add(item);
            }
        }

        return allSnapes;
    }
    public int AllSnapesCount()
    {
        return GetMergeSnapesCount() + GetBonusSnapesCount();
    }

    public MergeSnapesInLevel GetMergeSnape(int index)
    {
        return mergeSnapes[index];
    }
    public IList<MergeSnapesInLevel> GetMergeSnapes()
    {
        return mergeSnapes;
    }
    public int GetMergeSnapesCount()
    {
        return mergeSnapes.Count;
    }


    public SnapeInLevel GetBonusSnape(int index)
    {
        return bonusSnapes.BonusSnapesInLevel[index];
    }
    public BonusSnapes GetBonusSnape()
    {
        return bonusSnapes;
    }
    public int GetBonusSnapesCount()
    {
        return bonusSnapes.BonusSnapesInLevel.Count;
    }
}


[System.Serializable]
public class MergeSnapesInLevel
{
    public SnapeInLevel IncomingSnape;
    public SnapeInLevel ReceivingSnape;
}


[System.Serializable]
public class BonusSnapes
{
    [Range(0, 10)] public int energyCount;

    [Space]
    [SerializeField] private List<SnapeInLevel> bonusSnapes;

    public IList<SnapeInLevel> BonusSnapesInLevel => bonusSnapes;
}