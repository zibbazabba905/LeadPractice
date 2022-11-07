using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    TargetMovement tMove;

    public TargetLayout tl;
    public Hat Hat;

    public Material HitColor;

    void Awake()
    {
        tMove = GetComponent<TargetMovement>();
    }

    public void GetHit(string HitPart)
    {
        tMove.TargetHit();
    }

    public void SetTarget(float Distance)
    {
        tMove.SetTarget(Distance);
        Hat.ResetHat();
    }
}