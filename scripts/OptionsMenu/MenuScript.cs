using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    //r stands for "reference"
    //rename things again

    public SensitivityLevels rPlayerSens;
    public ShootScript rShootScript;
    public HuntView rHuntView;
    public WeaponDisplay rWeaponDisplay;
    public HunterAim rHunterAim;
    public Text ControlText;

    [Header("Sensivity sliders")]
    public SliderScript rSensDown;
    public SliderScript rSensHip;
    public SliderScript rSensAds;


    [Header("Gun Options")]
    public SliderScript rBulletSpeed;
    public DropdownScript rWeaponDropdown;
    public ButtonScript rHuntViewButton;
    public ButtonScript rScopeUseButton;



    void Awake()
    {
        PopulateDropdown(rWeaponDropdown.DD, rShootScript.Guns);
    }
    void Start()
    {
        gameObject.SetActive(false);
        rWeaponDropdown.DD.value = 10;
        GunslingerControls(false);
        //do init while loop
    }

    public void SetDownSens(float value)
    {
        value = RoundVar(value);
        rSensDown.SetText(value);
        rPlayerSens.DownSens = value;
    }
    public void SetHipSens(float value)
    {
        value = RoundVar(value);
        rSensHip.SetText(value);
        rPlayerSens.HipSens = value;
    }
    public void SetAdsSens(float value)
    {
        value = RoundVar(value);
        rSensAds.SetText(value);
        rPlayerSens.ADSSens = value;
    }
    public void SetBulletSpeed(float value)
    {
        rBulletSpeed.SetText(value);
        rShootScript.BulletVelocity = value;
    }
    public void SetGunDropdown(int value)
    {
        rWeaponDisplay.SetGun(value);
    }
    public void SetViewStyle(bool value)
    {
        rHuntView.Lowered = value;
    }
    public void SetScopeUse(bool value)
    {
        rWeaponDisplay.UseScope = value;
    }
    public void GunslingerControls(bool value)
    {
        rHunterAim.UseGunslinger = value;
        ControlText.text = value ? "R-click: ADS,\nShift \"sprint\" " : "R-click: HipFire, \nR-click + Shift: ADS,\nShift \"sprint\" ";
    }

    public void QuitClicked()
    {
        GameManager.Instance.QuitGame();
    }
    
    private float RoundVar(float value)
    {
        return Mathf.Round(value * 100) / 100;
    }

    private void PopulateDropdown(Dropdown dropdown, GameObject[] optionsArray)
    {
        List<string> options = new List<string>();
        foreach (var option in optionsArray)
        {
            options.Add(option.name);
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }
}
