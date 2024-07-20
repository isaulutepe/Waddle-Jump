using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Obsticle : MonoBehaviour
{
    [SerializeField] private float rotationDuration=0.4f;

    private void Start()
    {
        RotateObject();
    }

    private void RotateObject()
    {
        //Sonsuz döngü

        transform.DORotate(new Vector3(0f, 0f, 360f), rotationDuration, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }
}
