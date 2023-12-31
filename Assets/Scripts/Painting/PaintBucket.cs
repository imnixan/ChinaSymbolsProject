﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PaintBucket : MonoBehaviour
{
    public float totalPool;
    private GameManager gm;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        gm = FindAnyObjectByType<GameManager>();
        totalPool = gm.GetMaxPoints();
    }

    public void UpdateBucket(int pointUsed)
    {
        float usedPercent = (float)pointUsed / (float)totalPool;
        image.fillAmount = 1 - usedPercent;
        if (pointUsed >= totalPool)
        {
            gm.StopPainting();
        }
    }
}
