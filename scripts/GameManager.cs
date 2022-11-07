using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject Player;
    public UnityEvent<float> IntONE;
    public UnityEvent SetTarget;
    public GameObject Menu;
    public GameObject Hud;
    public bool InMenus = false;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameInit();
    }
    private void GameInit()
    {
        Cursor.lockState = InMenus ? CursorLockMode.Confined : CursorLockMode.Locked;
        Cursor.visible = false;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        //Screen.SetResolution(1920, 1080, true);
        ResetGame();
    }
    public void ResetGame()
    {
        IntONE.Invoke(1);
        SetTarget.Invoke();
    }

    public void ToggleMenu()
    {
        InMenus = !InMenus;
        MetaSet();
    }

    private void MetaSet()
    {
        Menu.SetActive(InMenus);
        Hud.SetActive(!InMenus);
        Cursor.lockState = InMenus ? CursorLockMode.Confined : CursorLockMode.Locked;
        Cursor.visible = InMenus;
        Time.timeScale = InMenus ? 0 : 1;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Clicked");
        Application.Quit();
    }
}
