using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    public GameObject Ironsight;
    private ShootScript rShootscript;

    [Header("Sway Test")]
    public float XFreq;
    public float XAmp;
    public float YFreq;
    public float YAmp;



    private bool _useScope;
    public bool UseScope
    {
        get { return _useScope; }
        set { _useScope = value; }
    }

    void Awake()
    {
        rShootscript = GetComponent<ShootScript>();
    }

    public void SetGun(int index)
    {
        //ADD make list a list of gunscripts instead of gameobjects
        //Ironsight = Game Object Hud Element
        //Guns = Game Object Array
        //GunScript = the class that holds the gun info
        //Ironsights = Texture/image of the gun
        Ironsight.GetComponent<RawImage>().material.mainTexture = rShootscript.Guns[index].GetComponent<GunScript>().Ironsights;
    }
     void Update()
    {
        Ironsight.transform.position = Ironsight.transform.position + SwayTest();
    }

    //sway should go into mouselook
    public void SetSway(float xfreq, float xamp, float yfreq, float yamp)
    {
        XFreq = xfreq;
        XAmp = xamp;
        YFreq = yfreq;
        YAmp = yamp;
    }

    public Vector3 SwayTest()
    {
        float x = Mathf.Cos(Time.time * XFreq) * XAmp;
        float y = Mathf.Sin(Time.time * YFreq) * YAmp;
        float z = 0;

        return new Vector3(x, y, z);
    }
}
