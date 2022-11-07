using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLayout : MonoBehaviour
{

    //this is where target layout select will form
    public static TargetLayout Instance { get; private set; }
    public GameObject Target;
    public TargetScript m_Target;

    private float distance;
    public float Distance
    {
        get { return distance; }
        set { distance = value; }
    }
    public bool Lefting;
    public bool Sprinting;

    public Vector3 BoundPoint;
    public float HalfRangeWidth;

    void Awake()
    {
        Instance = this;
    }

    public void SetTarget()
    {
        m_Target.SetTarget(Distance);
    }

    public void IncreaseDistance()
    {
        if (Distance < 20)
            Distance++;
        SetTarget();
    }
    public void DecreaseDistance()
    {
        if (Distance > 1)
            Distance--;
        SetTarget();
    }
}
