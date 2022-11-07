using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensitivityLevels : MonoBehaviour
{
    private float _downSens;
    public float DownSens
    {
        get { return _downSens; }
        set { _downSens = value; }
    }

    private float _hipSens;
    public float HipSens
    {
        get { return _hipSens; }
        set { _hipSens = value; }
    }

    private float _adsSens;
    public float ADSSens
    {
        get { return _adsSens; }
        set { _adsSens = value; }
    }

    private void Awake()
    {
        //set these settings probably in start
    }
}
