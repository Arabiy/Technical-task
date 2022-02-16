using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public abstract class Snape : MonoBehaviour
{
    [SerializeField] private int size;
    public int Size => size;

    public virtual void SetSize(int size)
    {
        this.size = size;
        CalculateScale();
    }

    public virtual void CalculateScale()
    {
        transform.localScale = new Vector3(size / 10f, size / 10f, size /10f);
    }

}
