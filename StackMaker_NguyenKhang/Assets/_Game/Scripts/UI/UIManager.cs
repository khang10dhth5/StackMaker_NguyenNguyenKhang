using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject pnlLevel;
    public GameObject pnlMainMenu;
    public GameObject pnlSetting;

    [SerializeField] private Button btnPlay;

    private void Start()
    {
        OnInit();
    }


    private void OnInit()
    {
        btnPlay.onClick.AddListener(() => {
            pnlLevel.SetActive(true);
            pnlMainMenu.SetActive(false);
        });
        pnlLevel.SetActive(false);
        pnlMainMenu.SetActive(true); 
    }


}
