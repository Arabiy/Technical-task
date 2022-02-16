using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SnapeInLevel
{
    [Range(10, 15)] public int Size;
    [Space]
    [Range(-5, 5)] public int PositionY;
    [Range(-8, 8)] public int PositionX;

    [Space]
    public Snape Snape;
}

