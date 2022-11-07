using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyInput : MonoBehaviour
{
    private WeaponDisplay rWeaponDisplay;

     void Awake()
    {
        rWeaponDisplay = GetComponent<WeaponDisplay>();
    }
    void Update()
    {
        if (!GameManager.Instance.InMenus)
        {
            HandleLiveInputs();
        }
        HandleGlobalInputs();
    }
    private void HandleLiveInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            TargetLayout.Instance.SetTarget();
        if (Input.GetKeyDown(KeyCode.E))
            TargetLayout.Instance.IncreaseDistance();
        if (Input.GetKeyDown(KeyCode.Q))
            TargetLayout.Instance.DecreaseDistance();
        ExtraShit();
    }
    private void HandleGlobalInputs()
    {
        //if (Application.isEditor ? Input.GetKeyDown(KeyCode.Tab) : Input.GetKeyDown(KeyCode.Escape))
        if (Input.GetKeyDown(KeyCode.Tab))
            GameManager.Instance.ToggleMenu();
    }
    private void ExtraShit()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
            rWeaponDisplay.SetSway(0, 0, 0, 0);
        if (Input.GetKeyDown(KeyCode.Alpha9))
            rWeaponDisplay.SetSway(7, 2, 4, 3);
        if (Input.GetKeyDown(KeyCode.Alpha8))
            rWeaponDisplay.SetSway(4, 0.5f, 1, 0.25f);
    }
}
