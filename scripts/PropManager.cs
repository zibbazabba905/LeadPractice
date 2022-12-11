using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropManager : MonoBehaviour
{
    public static PropManager Instance { get; private set; }
    public GameObject Cover;
    public GameObject Target;


    public float RangeHalfWidth { get; set; }
    public int ActiveRow { get; set; }


    public int CoverCount { get; set; }
    public float CoverPosition { get; set; }

    public List<GameObject> ActiveCoverPanels = new List<GameObject>();
    public List<TargetScript> TargetList = new List<TargetScript>();


    //target options
    public bool CanWalk { get; set; }
    public bool CanRun { get; set; }
    public bool RandomSpawn { get; set; }
    public float TwitchTime { get; set; }


    public void Awake()
    {
        Instance = this;
        TestFilling();
    }

    private void TestFilling()
    {
        ActiveRow = 10;
        RangeHalfWidth = 10;
        CanRun = true;
        CanWalk = true;
        RandomSpawn = true;
    }

    private void Start()
    {
        InitTarget();
    }

    public void InitCover(int count)
    {
        //Remove previous walls
        CoverCount = count;
        foreach (GameObject wall in ActiveCoverPanels)
        {
            Destroy(wall);
        }

        //spawn new walls
        for (int i = 1; i < CoverCount+1; i++)
        {
            float x = CenterJustifiedCover(i);
            float y = 0f;
            float z = ActiveRow;

            GameObject WallClone = Instantiate(Cover, new Vector3(x,y,z), transform.rotation);
            ActiveCoverPanels.Add(WallClone);
        }
    }
    private float CenterJustifiedCover(int WhichCover)
    {
        //space walls evenly, probably better math for this, but it's only 3 walls
        float widthPercent = (float)WhichCover / ((float)CoverCount + 1f);
        return Mathf.Lerp(-RangeHalfWidth, RangeHalfWidth, widthPercent);
    }

    public void InitTarget()
    {
        float x = 0;
        float y = 1;
        float z = ActiveRow;

        GameObject NewTarget = Instantiate(Target, new Vector3(x, y, z), transform.rotation);
        TargetList.Add(NewTarget.GetComponent<TargetScript>());
        ResetTargets();
    }

    public void ResetTargets()
    {
        foreach (TargetScript target in TargetList)
        {
            target.SetTarget();
        }
        InitCover(CoverCount);
    }
    public void IncreaseDistance()
    {
        if (ActiveRow < 200)
            ActiveRow += 10;
        ResetTargets();
    }
    public void DecreaseDistance()
    {
        if (ActiveRow > 10)
            ActiveRow -= 10;
        ResetTargets();
    }
}

