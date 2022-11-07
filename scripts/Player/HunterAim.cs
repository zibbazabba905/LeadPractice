using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



//ADD this is where to add the different scope zooms for now
public class HunterAim : MonoBehaviour
{
    public Camera FpsCam;
    public MouseLook ML;
    public GameObject CenterX;
    public GameObject ScopeView;
    public GameObject Ironsight;

    public GunScript CurrentGun;
    private SensitivityLevels rSensLevels;
    private WeaponDisplay rWeaponDisplay;
    public bool UseGunslinger;
    public bool CanShoot;

    void Awake()
    {
        rSensLevels = GetComponent<SensitivityLevels>();
        rWeaponDisplay = GetComponent<WeaponDisplay>();
    }

    void Update()
    {
        if (!GameManager.Instance.InMenus)

            if (UseGunslinger)
                GunslingerControl();
            else
                HunterControl();
    }

    private void HunterControl()
    {
        if (!Input.GetMouseButton(1)) //right click
        {
            DownView();
            return;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            ADSView();
            return;
        }

        HipView();
    }
    public void GunslingerControl()
    {
        if (Input.GetMouseButton(1)) //right click
        {
            ADSView();
            return;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            DownView();
            return;
        }

        HipView();
    }

    private void DownView()
    {
        FpsCam.fieldOfView = Camera.HorizontalToVerticalFieldOfView(90f, 1.777f); ;
        ML.Sens = rSensLevels.DownSens;
        CanShoot = false;
        ScopeView.SetActive(false);
        Ironsight.SetActive(false);
        CenterX.SetActive(false);
    }
    private void HipView()
    {
        FpsCam.fieldOfView = Camera.HorizontalToVerticalFieldOfView(75f, 1.777f);
        ML.Sens = rSensLevels.HipSens;
        CanShoot = true;
        ScopeView.SetActive(false);
        Ironsight.SetActive(false);
        CenterX.SetActive(true);


    }
    private void ADSView()
    {
        FpsCam.fieldOfView = Camera.HorizontalToVerticalFieldOfView(rWeaponDisplay.UseScope ? 10f : 50f, 1.777f);
        ML.Sens = rSensLevels.ADSSens;
        CanShoot = true;

        if (rWeaponDisplay.UseScope)
        {
            ScopeView.SetActive(true);
            CenterX.SetActive(false);
            Ironsight.SetActive(false);
        }
        else
        {
            CenterX.SetActive(false);
            Ironsight.SetActive(true);
        }
    }
}
//down is 90
//hip is 75
//aim is 50
//sniper scope is 10
//sens

//down 2    1.6
//hip .72   1.3
//aim .44   0.65

/*
 * 1920 960
 * 1080 540
 * 
 * 600 px wide
 * 660 px start x 600 wide
 * 
 * 
 * 108 px down from center
 * */
